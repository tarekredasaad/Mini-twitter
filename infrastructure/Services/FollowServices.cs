using domain.DTO;
using Domain.DTO;
using domain.Models;
using Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Services
{
    public class FollowServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public FollowServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultDTO> FollowIfExistOrUnfollow(FollowDTO followDTO)
        {
            if (followDTO.User != null && followDTO.TargetUserFollow != null)
            {
                Follow follow = new Follow();
                follow.User = followDTO.User;
                follow.TargetUserFollow = followDTO.TargetUserFollow;
                if(!checkFollowExist(follow.User, follow.TargetUserFollow))
                {
                    _unitOfWork.FollowRepository.Create(follow);
                    _unitOfWork.commit();

                    return new ResultDTO()
                    {
                        StatusCode = 200,
                        Data = "follow Is Created successfully"
                    };
                }
                else
                {
                   Follow existFollow = _unitOfWork.FollowRepository.Get(f=>f.User == followDTO.User);
                    _unitOfWork.FollowRepository.Delete(existFollow.Id);
                    return new ResultDTO() { StatusCode = 200, Data = "unfollow Is done successfully" };

                }
            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
        }


        public bool checkFollowExist(string user, string userTarget)
        {
            List<Follow> FollowList = new List<Follow>();
            FollowList = (List<Follow>)_unitOfWork.FollowRepository.GetAll(f => f.User == user);
            Boolean check = false;
            foreach (Follow Follow in FollowList)
            {
                if (Follow.TargetUserFollow == userTarget)
                {
                    check = true;
                    return check;
                }
            }
            return (check);
        }
    }
}

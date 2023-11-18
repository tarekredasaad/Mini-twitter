using domain.DTO;
using domain.Models;
using Domain.DTO;
using Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Services
{
    public class LikeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public LikeServices(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultDTO> AddLikeIfNotExistOrDeleted(LikeDTO likeDTO)
        {
            if (likeDTO.PostId != null && likeDTO.OwnerLike != null)
            {
                Like like = new Like();
                like.PostId = likeDTO.PostId;
                like.OwnerLike = likeDTO.OwnerLike;
                tweetPost tweet = _unitOfWork.PostRepository.GetById(like.PostId);
                if (!checkLikeExist(like.PostId, like.OwnerLike))
                {
                    tweet.Likes++;
                    _unitOfWork.LikeRepository.Create(like);
                    _unitOfWork.PostRepository.Update(tweet);
                    _unitOfWork.commit();
                    return new ResultDTO()
                    {
                        StatusCode = 200,
                        Data = "like Is Added successfully"
                    };
                }
                else
                {
                    Like Like = _unitOfWork.LikeRepository.Get(l=>l.OwnerLike == likeDTO.OwnerLike && l.PostId == likeDTO.PostId);
                    tweet.Likes--;
                    _unitOfWork.LikeRepository.Delete(Like.Id);
                    _unitOfWork.PostRepository.Update(tweet);
                    _unitOfWork.commit();
                    return new ResultDTO() { StatusCode = 400, Data = "this Like is  Deleted " };

                }
            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
        }

        public bool checkLikeExist(int postId, string userId)
        {
            List<Like> likeList = new List<Like>();
            likeList = (List<Like>)_unitOfWork.LikeRepository.GetAll(k => k.PostId == postId);
            Boolean check = false;
            foreach (Like like in likeList)
            {
                if (like.OwnerLike == userId)
                {
                    check = true;
                    return check;
                }
            }
            return (check);
        }

    }
}

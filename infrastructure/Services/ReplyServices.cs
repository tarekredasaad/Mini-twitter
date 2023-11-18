using domain.DTO;
using domain.Models;
using Domain.DTO;
using Domain.Interfaces.UnitOfWork;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Services
{
    public class ReplyServices
    {
        private readonly IUnitOfWork unitOfWork;

        public ReplyServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResultDTO> AddReply(ReplyDTO ReplyDTO)
        {
            if (ReplyDTO.PostId != null && ReplyDTO.UserId != null)
            {
                Reply reply = new Reply();
                reply.PostId = ReplyDTO.PostId;
                reply.UserId = ReplyDTO.UserId;

                unitOfWork.ReplyRepository.Create(reply);
                unitOfWork.commit();
                return new ResultDTO()
                {
                    StatusCode = 200,
                    Data = "reply Is Added successfully"
                };
            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
        }
    }
}

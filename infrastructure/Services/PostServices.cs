using domain.Models;
using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
//using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PostServices  : IPostServicce
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostServices(IUnitOfWork unitOfWork) 
        {
         _unitOfWork = unitOfWork;
        }
        public async Task<ResultDTO> AddPost(CreatePostDTO PostDTO)
        {
            if (PostDTO.UserId != null && PostDTO.PostContent != null)
            {
                tweetPost post = new tweetPost();
                post.UserId = PostDTO.UserId;
                post.content = PostDTO.PostContent ;
                post.status = statusPost.New;
                post.Likes = 0;
                post.Replies = 0;
                _unitOfWork.PostRepository.Create(post);
                _unitOfWork.commit();
                return new ResultDTO()
                {
                    StatusCode = 200,
                    Data = "post Is Added successfully"
                };
            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
        }

        public async Task<ResultDTO> Retweet(int Id, CreatePostDTO PostDTO)
        {
            if (PostDTO.UserId != null && Id != null )
            {
                tweetPost oldPost = _unitOfWork.PostRepository.GetById(Id);
                tweetPost post = new tweetPost();
                post.UserId = PostDTO.UserId;
                post.content = PostDTO.PostContent + "  "+ oldPost.content;
                post.status = statusPost.Retweet;
                post.Likes = 0;
                post.Replies = 0;
                post.retweetId = Id;
                _unitOfWork.PostRepository.Create(post);
                _unitOfWork.commit();
                return new ResultDTO()
                {
                    StatusCode = 200,
                    Data = "Repost Is Added successfully"
                };
            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
        }
        public async Task<ResultDTO> GetFollersPosts(string id, int take = 5,int skip = 5)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };

            }
            else
            {
                List<Follow> followers = (List<Follow>)_unitOfWork.FollowRepository.GetAll(f => f.TargetUserFollow == id);
                List<tweetPost> posts = new List<tweetPost>();
                foreach (Follow f in followers)
                {
                    tweetPost tweet = _unitOfWork.PostRepository.Get(t => t.UserId == f.User);
                    posts.Add(tweet);

                }
                return new ResultDTO() { StatusCode = 200, Data = posts };
            }
        }
        public async Task<ResultDTO> EditPost(int id, CreatePostDTO PostDTO)
        {
            if (PostDTO.UserId != null && PostDTO.PostContent != null && id != null)
            {
                tweetPost post = _unitOfWork.PostRepository.GetById(id);
                
                post.content = PostDTO.PostContent;
                
                _unitOfWork.PostRepository.Update(post);
                _unitOfWork.commit();
                return new ResultDTO()
                {
                    StatusCode = 200,
                    Data = "post Is Updated successfully"
                };
            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
        }
         public async Task<ResultDTO> DeletePost(int id)
         {
            if ( id != null)
            {
                tweetPost post = _unitOfWork.PostRepository.GetById(id);
                
                
                
                _unitOfWork.PostRepository.Delete(id);
                _unitOfWork.commit();
                return new ResultDTO()
                {
                    StatusCode = 200,
                    Data = "post Is Deleted successfully"
                };
            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }

         }


    }
}

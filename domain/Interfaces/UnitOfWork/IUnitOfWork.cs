using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Models;

namespace Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        public IRepository<ApplicationUser> UserRepository { get; }
        public IRepository<tweetPost> PostRepository { get; }
        public IRepository<Like> LikeRepository { get; }
        public IRepository<Reply> ReplyRepository { get; }
        public IRepository<Follow> FollowRepository { get; }
       
        void commit();
    }
}

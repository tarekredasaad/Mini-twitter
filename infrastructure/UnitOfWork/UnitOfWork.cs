﻿using Domain;
using Domain.Interfaces.Repository;
using Infrastructure.Repository;
using Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Domain.Models;
using Microsoft.EntityFrameworkCore;
using domain.Models;
using infrastructure;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly Context Context;
        public IRepository<ApplicationUser> UserRepository { get;private set; }
        public IRepository<tweetPost> PostRepository { get;private set; }
        public IRepository<Like> LikeRepository { get;private set; }
        public IRepository<Reply> ReplyRepository { get;private set; }
        public IRepository<Follow> FollowRepository { get;private set; }

        //public IRepository<Product> ProductRepository { get; private set; }

        //public IRepository<Permission> PermissionRepository { get; private set; }



        //public IRepository<User> Users => throw new NotImplementedException();

        public UnitOfWork(Context context) 
        {
            Context = context;
            UserRepository = new Repository<ApplicationUser>(Context);
            PostRepository = new Repository<tweetPost>(Context);
            LikeRepository = new Repository<Like>(Context);
            ReplyRepository = new Repository<Reply>(Context);
            FollowRepository = new Repository<Follow>(Context);
            //ProductRepository = new Repository<Product>(Context);
            //PermissionRepository = new Repository<Permission>(Context);

        }
        public void commit() 
        {
            //try
            //{
                Context.SaveChanges();
                //Context.Database.CurrentTransaction.Commit();
            //}
            //catch
            //{
            //    Context.Database.CurrentTransaction.Rollback();
            //}
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

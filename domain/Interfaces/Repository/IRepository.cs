﻿using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IRepository<T>
    {
       public T GetById(int id);
        public T Get(Expression<Func<T, bool>> expression);
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
        public T Update(T entity);
        public void Delete(int id);
         T Create(T entity);
    }
}

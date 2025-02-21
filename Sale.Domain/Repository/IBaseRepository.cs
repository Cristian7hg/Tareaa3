﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sale.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetEntities();
        TEntity GetEntity(int id);


        bool Exists(Expression<Func<TEntity, bool>> filter);
        List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
        
        
    }
}

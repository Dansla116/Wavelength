using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Wavelength.DAL.DomainModels;

namespace Wavelength.DAL.Repository {
    public interface IRepository<TEntity> where TEntity : IEntity {
        TEntity Create(TEntity entity);
        List<TEntity> Create(List<TEntity> entities);
        TEntity Get(int id);
        List<TEntity> Read(List<int> ids);
        IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> predicate);
        TEntity ReadOne(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> ReadAll();
        TEntity Update(TEntity entity);
        List<TEntity> Update(List<TEntity> entities);
        TEntity Delete(int id);
        List<TEntity> Delete(List<int> ids);
        void Save();
    }

    public interface ICardRepo : IRepository<CardData> { }
}
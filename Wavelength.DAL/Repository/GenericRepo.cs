using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Wavelength.DAL.Context;
using Wavelength.DAL.DomainModels;
using EntityState = System.Data.Entity.EntityState;

namespace Wavelength.DAL.Repository {
    public class GenericRepo<TEntity> : IRepository<TEntity> where TEntity : class, IEntity {
        private readonly IDBContext _context;

        public GenericRepo(IDBContext context) {
            _context = context;
        }

        private IDbSet<TEntity> DbSet {
            get {
                return _context.Set<TEntity>();
            }
        }
        
        /* Create */
        public TEntity Create(TEntity entity) {
            TEntity result;
            result = DbSet.Add(entity);
            Save();
            return result;
        }
        public List<TEntity> Create(List<TEntity> entities) {
            var returnable = new List<TEntity>();
            foreach (var entity in entities) {
                DbSet.Add(entity);
                returnable.Add(entity);
            }
            Save();
            return returnable;
        }

        /* Read */
        public TEntity Get(int id) {
            return DbSet.First(x => x.id == id);
        }
        public List<TEntity> Read(List<int> ids) {
            return DbSet.Where(x => ids.Contains(x.id)).ToList();
        }
        public IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> predicate) {
            return DbSet.Where(predicate);
        }
        public TEntity ReadOne(Expression<Func<TEntity, bool>> predicate) {
            return DbSet.FirstOrDefault(predicate);
        }
        public IQueryable<TEntity> ReadAll() {
            //return DbSet.AsQueryable();
            return this.DbSet;
        }

        /* Update */
        public TEntity Update(TEntity entity) {
            TEntity returnable;
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            _context.Entry(entity).State = EntityState.Modified;
            returnable = entity;
            Save();
            return returnable;
        }
        public List<TEntity> Update(List<TEntity> entities) {
            var returnable = new List<TEntity>();
            foreach (var entity in entities) {
                if (entity == null) {
                    throw new ArgumentNullException("entity");
                }
                _context.Entry(entity).State = EntityState.Modified;
                returnable.Add(entity);
            }
            Save();
            return returnable;
        }

        /* Update */
        public TEntity Delete(int id) {
            TEntity entity = DbSet.First(d => d.id == id);
            _context.Entry(entity).State = EntityState.Deleted;
            Save();
            return entity;
        }
        public List<TEntity> Delete(List<int> ids) {
            List<TEntity> returnable = new List<TEntity>();
            IQueryable<TEntity> entities = DbSet.Where(d => ids.Contains(d.id));
            foreach (var entity in entities) {
                if (entity == null) {
                    throw new ArgumentNullException("entity");
                }
                _context.Entry(entity).State = EntityState.Deleted;
                returnable.Add(entity);
            }

            Save();
            return returnable;
        }

        public void Save() {
            _context.SaveChanges();
        }
    }

    public class CardRepo : GenericRepo<CardData>, ICardRepo {
        public CardRepo(IDBContext Context) : base(Context) { }
    }

    public class GameRepo : GenericRepo<GameData>, IGameRepo {
        public GameRepo(IDBContext Context) : base(Context) { }
    }

    public class UserRepo : GenericRepo<UserData>, IUserRepo {
        public UserRepo(IDBContext Context) : base(Context) { }
    }
}
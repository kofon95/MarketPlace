using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repository
{
    class SqlRepository<TEntity> : IRepository<TEntity, int>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _entities;
        private readonly DbContext _context;

        public SqlRepository(DbSet<TEntity> entities, DbContext context)
        {
            _entities = entities;
            _context = context;
        }

        #region Select

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities;
        }
        public virtual TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        #endregion


        #region Delete

        public virtual void Delete(TEntity entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }
        public virtual void DeleteById(int id)
        {
            var entity = _entities.Find(id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }
        public virtual void Delete(TEntity[] entities)
        {
            _entities.RemoveRange(entities);
            _context.SaveChanges();
            //throw new NotImplementedException("Not implemented");
        }

        #endregion


        #region Insert

        public virtual TEntity Save(TEntity entity)
        {
            var added = _entities.Add(entity);
            _context.SaveChanges();
            return added;
        }
        public virtual IEnumerable<TEntity> Save(params TEntity[] entity)
        {
            var added = _entities.AddRange(entity);
            _context.SaveChanges();
            return added;
        }

        #endregion

        #region Update

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Argument cannot be null");

            _context.SaveChanges();
        }

        #endregion
    }
}

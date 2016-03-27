using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public interface IRepository<TEntity, TIdType>
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);

        void Delete(TEntity entity);
        void DeleteById(int id);
        void Delete(TEntity[] entities);

        TEntity Save(TEntity entity);
        IEnumerable<TEntity> Save(params TEntity[] entity);

        void Update(TEntity entity);
    }
}

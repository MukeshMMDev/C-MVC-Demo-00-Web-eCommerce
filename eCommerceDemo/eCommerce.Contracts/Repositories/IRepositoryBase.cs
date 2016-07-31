using System.Linq;

namespace eCommerce.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Commit();
        void Delete(object id);
        void Dispose();
        IQueryable<TEntity> GetAll(object id);
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}
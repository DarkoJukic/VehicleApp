using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VehicleApp.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        // Not used
        //void AddRange(IEnumerable<TEntity> entities);
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        //void RemoveRange(IEnumerable<TEntity> entities);
    }
}

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Child.Growth.src.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filterExpression);
        IEnumerable<TEntity> GetByFilters(string filters);
        EntityEntry<TEntity> Add(TEntity entity);
        EntityEntry<TEntity> Update(TEntity entity);
        EntityEntry<TEntity> Remove(long id);
    }
}
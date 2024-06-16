using System.Linq.Expressions;
using Child.Growth.src.Infra.Data;
using Child.Growth.src.Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Child.Growth.src.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TEntity GetById(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filterExpression)
        {
            return _context.Set<TEntity>()
                .Where(filterExpression)
                .AsQueryable();
        }

        public IEnumerable<TEntity> GetByFilters(string filters)
        {
            var decodedFilters = System.Net.WebUtility.UrlDecode(filters);
            var parsedFilters = JsonConvert.DeserializeObject<List<FilterModel>>(decodedFilters);

            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var filter in parsedFilters)
            {
                switch (filter.Operation)
                {
                    case "Equals":
                        query = query.Where(e => EF.Property<string>(e, filter.PropertyName) == filter.Value);
                        break;
                    case "NotEquals":
                        query = query.Where(e => EF.Property<string>(e, filter.PropertyName) != filter.Value);
                        break;
                    case "Contains":
                        query = query.Where(e => EF.Property<string>(e, filter.PropertyName).Contains(filter.Value));
                        break;
                    default:
                        break;
                }
            }

            return query.ToList();
        }

        public EntityEntry<TEntity> Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public EntityEntry<TEntity> Update(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity);
        }

        public EntityEntry<TEntity> Remove(long id)
        {
            var entity = GetById(id);
            return _context.Set<TEntity>().Remove(entity);
        }
    }

}
using System.Linq.Expressions;
using Accounting.Project.src.Entities.Base;
using Accounting.Project.src.Infra.Data.UnitOfWork;
using Accounting.Project.src.Infra.Exceptions;
using Accounting.Project.src.Infra.Responses;
using Accounting.Project.src.Repositories.Base;

namespace Accounting.Project.src.Services.Base
{
    public class ServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        private readonly IRepository<T> _repository;

        private readonly IUnitOfWork _uow;

        public ServiceBase(IRepository<T> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public ResponseBody GetAll()
        {
            var content = _repository.GetAll().ToList();

            return new ResponseBody
            {
                Code = 200,
                Message = "Registros atualizados retornados.",
                Content = content
            };
        }

        public List<T> GetByFilters(string filters)
        {
            return _repository.GetByFilters(filters).ToList();
        }

        public ResponseBody GetById(long id)
        {
            return new ResponseBody
            {
                Code = 200,
                Message = "Registro localizado com sucesso.",
                Content = _repository.GetById(id)
            };
        }

        public IEnumerable<T> Query(
            Expression<Func<T, bool>> filterExpression,
            params Expression<Func<T, object>>[] includes
        )
        {
            return _repository.Query(filterExpression, includes);
        }

        public ResponseBody Create(T entity)
        {
            if (entity == null)
                throw new BusinessException($"Ocorreu um erro ao criar {entity.GetType().FullName}, entidade está null");

            entity.CreatedAt = DateTime.Now;

            try
            {
                var newEntity = _repository.Add(entity);

                if (newEntity != null && newEntity.Entity != null)
                {
                    _uow.SaveChanges();

                    return new ResponseBody
                    {
                        Code = 200,
                        Message = "Registro criado com sucesso",
                        Content = newEntity.Entity
                    };
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseBody Update(T entity)
        {
            if (entity == null)
                throw new BusinessException($"Ocorreu um erro ao criar {entity.GetType().FullName}, entidade está null");

            entity.ModifiedAt = DateTime.Now;

            try
            {
                var newEntity = _repository.Update(entity);

                if (newEntity != null && newEntity.Entity != null)
                {
                    _uow.SaveChanges();

                    return new ResponseBody
                    {
                        Code = 200,
                        Message = "Registro atualizado com sucesso.",
                        Content = newEntity.Entity
                    };
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseBody Delete(long id)
        {
            if (id == default)
                throw new BusinessException("Id não informado corretamente.");

            try
            {
                var newEntity = _repository.Remove(id);

                if (newEntity != null && newEntity.Entity != null)
                {
                    _uow.SaveChanges();

                    return new ResponseBody
                    {
                        Code = 200,
                        Message = "Registro deletado com sucesso.",
                        Content = newEntity.Entity
                    };
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
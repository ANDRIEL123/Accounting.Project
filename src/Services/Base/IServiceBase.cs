using Accounting.Project.src.Infra.Responses;

namespace Accounting.Project.src.Services.Base
{
    public interface IServiceBase<T>
    {
        ResponseBody Create(T entity);

        ResponseBody Update(T entity);

        ResponseBody Delete(long id);

        ResponseBody GetById(long id);

        ResponseBody GetAll();

        List<T> GetByFilters(string filters);
    }
}
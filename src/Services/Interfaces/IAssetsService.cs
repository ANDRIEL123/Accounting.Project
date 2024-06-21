using Accounting.Project.src.Entities;
using Accounting.Project.src.Infra.Responses;
using Accounting.Project.src.Services.Base;

namespace Accounting.Project.src.Services.Interfaces
{
    public interface IAssetsService : IServiceBase<Assets>
    {
        ResponseBody GetOptions();
    }
}
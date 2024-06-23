using Accounting.Project.src.Entities;
using Accounting.Project.src.Services.Base;

namespace Accounting.Project.src.Services.Interfaces
{
    public interface IReleasesService : IServiceBase<Releases>
    {
        object PatrimonyBalance();
    }
}
using Accounting.Project.src.Infra.Data.UnitOfWork;
using Accounting.Project.src.Entities;
using Accounting.Project.src.Services.Interfaces;
using Accounting.Project.src.Services.Base;
using Accounting.Project.src.Repositories.Base;

namespace Accounting.Project.src.Services.Implementations
{
    public class ReleasesService : ServiceBase<Releases>, IReleasesService
    {
        public ReleasesService(
            IRepository<Releases> repository,
            IUnitOfWork uow
        ) : base(repository, uow)
        {
        }
    }
}
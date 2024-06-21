using Accounting.Project.src.Infra.Data.UnitOfWork;
using Accounting.Project.src.Entities;
using Accounting.Project.src.Services.Interfaces;
using Accounting.Project.src.Services.Base;
using Accounting.Project.src.Repositories.Base;
using Accounting.Project.src.Infra.Responses;

namespace Accounting.Project.src.Services.Implementations
{
    public class PeopleService : ServiceBase<People>, IPeopleService
    {
        private readonly IRepository<People> _repository;

        public PeopleService(
            IRepository<People> repository,
            IUnitOfWork uow
        ) : base(repository, uow)
        {
            _repository = repository;
        }

        public ResponseBody GetOptions()
        {
            var responsible = _repository
                .GetAll()
                .Select(x => new
                {
                    Label = x.Name,
                    Value = x.Id
                })
                .ToList();

            return new ResponseBody
            {
                Code = 200,
                Content = responsible
            };
        }
    }
}
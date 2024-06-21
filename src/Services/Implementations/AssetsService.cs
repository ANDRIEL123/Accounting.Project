using Accounting.Project.src.Infra.Data.UnitOfWork;
using Accounting.Project.src.Entities;
using Accounting.Project.src.Services.Interfaces;
using Accounting.Project.src.Services.Base;
using Accounting.Project.src.Repositories.Base;
using Accounting.Project.src.Infra.Responses;

namespace Accounting.Project.src.Services.Implementations
{
    public class AssetsService : ServiceBase<Assets>, IAssetsService
    {
        private readonly IRepository<Assets> _repository;

        public AssetsService(
            IRepository<Assets> repository,
            IUnitOfWork uow
        ) : base(repository, uow)
        {
            _repository = repository;
        }

        public new ResponseBody GetAll()
        {
            var assets = _repository
                .GetAll()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.PurchasePrice,
                    x.SellingPrice,
                    x.AccountId,
                    x.Type
                })
                .ToList();

            return new ResponseBody
            {
                Content = assets
            };
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
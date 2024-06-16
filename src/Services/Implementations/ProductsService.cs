using Child.Growth.src.Infra.Data.UnitOfWork;
using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Child.Growth.src.Services.Base;
using Child.Growth.src.Repositories.Base;
using Child.Growth.src.Infra.Responses;

namespace Child.Growth.src.Services.Implementations
{
    public class ProductsService : ServiceBase<Products>, IProductsService
    {
        private readonly IRepository<Products> _repository;

        public ProductsService(
            IRepository<Products> repository,
            IUnitOfWork uow
        ) : base(repository, uow)
        {
            _repository = repository;
        }

        public new ResponseBody GetAll()
        {
            var products = _repository
                .GetAll()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.IcmsDebit,
                    x.IcmsCredit,
                    x.PurchasePrice,
                    x.SellingPrice,
                    Cost = x.CalculateCost(),
                    Profit = x.CalculateProfit()
                })
                .ToList();

            return new ResponseBody
            {
                Content = products
            };
        }
    }
}
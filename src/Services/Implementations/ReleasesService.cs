using Accounting.Project.src.Infra.Data.UnitOfWork;
using Accounting.Project.src.Entities;
using Accounting.Project.src.Services.Interfaces;
using Accounting.Project.src.Services.Base;
using Accounting.Project.src.Repositories.Base;
using Accounting.Project.src.Infra.Responses;
using Accounting.Project.src.Infra.Enums;

namespace Accounting.Project.src.Services.Implementations
{
    public class ReleasesService : ServiceBase<Releases>, IReleasesService
    {
        private readonly IRepository<Releases> _repository;

        public ReleasesService(
            IRepository<Releases> repository,
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
                    x.TotalAmount,
                    x.AccountId,
                    x.Account.Name,
                    x.Type
                })
                .ToList();

            return new ResponseBody
            {
                Content = assets
            };
        }

        public object PatrimonyBalance()
        {
            var releasePatrimony = _repository
                .GetAll()
                .OrderBy(x => x.AccountId)
                .ThenBy(x => x.Account.Type)
                .GroupBy(x => x.AccountId)
                .Select(x => new
                {
                    AccountName = x.First().Account.Name,
                    TotalAmount = Math.Abs(x.Where(y => y.Type == FactType.Debit).Sum(y => y.TotalAmount) - x.Where(y => y.Type == FactType.Credit).Sum(y => y.TotalAmount)),
                    x.First().Account.Type,
                    x.First().Account.Current
                })
                .ToList();

            var report = new List<object>
            {
                new
                {
                    AccountName = "Ativo",
                    TotalAmount = releasePatrimony.Where(x => x.Type == AccountType.Active).Sum(x => x.TotalAmount)
                },
                new
                {
                    AccountName = "Ativo Circulante"
                }
            };

            // Adiciona os ativos circulantes
            report.AddRange(releasePatrimony.Where(x => x.Type == AccountType.Active && x.Current == CurrentTypeEnum.CurrentAssets));

            report.Add(new
            {
                AccountName = "Ativo não Circulante"
            });

            // Adiciona os ativos não circulantes
            report.AddRange(releasePatrimony.Where(x => x.Type == AccountType.Active && x.Current == CurrentTypeEnum.NotCurrentAssets));

            // Adiciona passivo
            report.Add(new
            {
                AccountName = "Passivo",
                TotalAmount = releasePatrimony.Where(x => x.Type == AccountType.Passive).Sum(x => x.TotalAmount)
            });

            report.Add(new
            {
                AccountName = "Passivo Circulante"
            });

            // Adiciona passivos circulantes
            report.AddRange(releasePatrimony.Where(x => x.Type == AccountType.Passive && x.Current == CurrentTypeEnum.CurrentLiabilities));

            report.Add(new
            {
                AccountName = "Passivo não Circulante"
            });

            // Adiciona passivos não circulantes
            report.AddRange(releasePatrimony.Where(x => x.Type == AccountType.Passive && x.Current == CurrentTypeEnum.NotCurrentLiabilities));

            report.Add(new
            {
                AccountName = "Patrimônio Líquido",
                TotalAmount = releasePatrimony.Where(x => x.Type == AccountType.NetWorth).Sum(x => x.TotalAmount)
            });

            report.AddRange(releasePatrimony.Where(x => x.Type == AccountType.NetWorth));

            return report;
        }
    }
}
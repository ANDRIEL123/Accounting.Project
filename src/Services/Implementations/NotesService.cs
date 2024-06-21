using Accounting.Project.src.Infra.Data.UnitOfWork;
using Accounting.Project.src.Entities;
using Accounting.Project.src.Services.Interfaces;
using Accounting.Project.src.Services.Base;
using Accounting.Project.src.Repositories.Base;
using Accounting.Project.src.Infra.Responses;
using Accounting.Project.src.Infra.Enums;

namespace Accounting.Project.src.Services.Implementations
{
    public class NotesService : ServiceBase<Notes>, INotesService
    {
        IRepository<Notes> _repository;
        IReleasesService _releasesService;

        public NotesService(
            IRepository<Notes> repository,
            IReleasesService releasesService,
            IUnitOfWork uow
        ) : base(repository, uow)
        {
            _repository = repository;
            _releasesService = releasesService;
        }

        public new ResponseBody Create(Notes note)
        {
            var response = base.Create(note);

            // Se criou a nota com sucesso gera os lançamentos
            if (response.Code == 200)
            {
                var entityDb = _repository
                    .Query(x =>
                        x.Id == note.Id,
                        e => e.Asset,
                        e => e.Asset.Account
                    )
                    .FirstOrDefault();

                GenerateReleases(entityDb);
            }

            return response;
        }

        private void GenerateReleases(Notes note)
        {
            if (note.Signal == SignalTypeEnum.Entry)
            {
                // Se for a vista
                if (note.Operation == OperationTypeEnum.InCash)
                {
                    // Credita do caixa
                    var creditRelease = new Releases
                    {
                        AccountId = note.Asset.AccountId,
                        TotalAmount = note.Asset.PurchasePrice,
                        Type = FactType.Credit
                    };

                    _releasesService.Create(creditRelease);

                    // Debita na conta contábil associada ao bem/produto
                    var debitRelease = new Releases
                    {
                        AccountId = note.Asset.Account.MatchAccountId ?? 1,
                        TotalAmount = note.Asset.PurchasePrice,
                        Type = FactType.Debit
                    };

                    _releasesService.Create(debitRelease);
                }
            }
        }
    }
}
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
        IRepository<Accounts> _accountsRepository;
        IReleasesService _releasesService;

        public NotesService(
            IRepository<Notes> repository,
            IRepository<Accounts> accountsRepository,
            IReleasesService releasesService,
            IUnitOfWork uow
        ) : base(repository, uow)
        {
            _repository = repository;
            _accountsRepository = accountsRepository;
            _releasesService = releasesService;
        }

        public new ResponseBody GetAll()
        {
            var assets = _repository
                .GetAll()
                .Select(x => new
                {
                    x.Id,
                    x.Operation,
                    x.Signal,
                    PersonName = x.Person.Name,
                    AssetName = x.Asset.Name,
                    x.PersonId,
                    x.AssetId
                })
                .ToList();

            return new ResponseBody
            {
                Content = assets
            };
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

        /// <summary>
        /// Gera os lançamentos contábeis
        /// </summary>
        /// <param name="note"></param>
        private void GenerateReleases(Notes note)
        {
            // Se for um bem não tem ICMS a recuperar, por ser cliente final, os impostos são absorvidos
            // Se entrada e um produto lança na conta "ICMS a Recuperar"
            if (note.Signal == SignalTypeEnum.Entry)
                Entry(note);
            else if (note.Signal == SignalTypeEnum.Out)
                Out(note);
        }

        /// <summary>
        /// Realiza operações quando é uma nota de entrada
        /// </summary>
        /// <param name="note"></param>
        private void Entry(Notes note)
        {
            var icmsRecovery = note.Asset.PurchasePrice * 0.17m;

            GenerateMatches(note, icmsRecovery);

            // Se for bem não lança no ICMS a recuperar
            if (note.Asset.Type == AssetsTypeEnum.Assets)
                return;

            var icmsRecoveryAccountId = _accountsRepository
                .Query(x => x.Code == "6")
                .Select(x => x.Id)
                .FirstOrDefault();

            // Debita na conta
            var creditRelease = new Releases
            {
                AccountId = icmsRecoveryAccountId,
                TotalAmount = icmsRecovery,
                Type = FactType.Debit
            };

            _releasesService.Create(creditRelease);
        }

        /// <summary>
        /// Realiza operações quando é uma nota de saída
        /// </summary>
        /// <param name="note"></param>
        private void Out(Notes note)
        {
            GenerateMatches(note);

            // Se saída lança na conta "ICMS a Recolher"
            var icmsRecoveryAccountId = _accountsRepository
                .Query(x => x.Code == "10")
                .Select(x => x.Id)
                .FirstOrDefault();

            var icmsRecovery = (note.Asset.SellingPrice ?? 0) * 0.17m;

            // Debita na conta a recolher
            var creditRelease = new Releases
            {
                AccountId = icmsRecoveryAccountId,
                TotalAmount = icmsRecovery,
                Type = FactType.Debit
            };

            _releasesService.Create(creditRelease);

            // Encontra conta de estoque
            var stockId = _accountsRepository
                .Query(x => x.Code == "5")
                .Select(x => x.Id)
                .FirstOrDefault();

            // É necessário verificar quanto tem em estoque
            var stockAmount = _releasesService
                .Query(x => x.AccountId == stockId)
                .Sum(x => x.TotalAmount);

            // O valor padrão é o valor da venda
            var total = note.Asset.SellingPrice;

            // Se o valor da venda é maior que o estoque, zera o estoque
            if (note.Asset.SellingPrice > stockAmount)
                total = stockAmount;

            // É necessário debitar na conta Custo das Mercadorias Vendidas
            var costReleaseId = _accountsRepository
                .Query(x => x.Code == "11")
                .Select(x => x.Id)
                .FirstOrDefault();

            // Cria lançamento a débito na conta 
            var debitReleaseStock = new Releases
            {
                AccountId = costReleaseId,
                TotalAmount = total ?? 0,
                Type = FactType.Debit
            };

            _releasesService.Create(debitReleaseStock);

            // Cria lançamento a crédito no estoque
            var creditReleaseStock = new Releases
            {
                AccountId = stockId,
                TotalAmount = total ?? 0,
                Type = FactType.Credit
            };

            _releasesService.Create(creditReleaseStock);
        }

        private void GenerateMatches(Notes note, decimal? icmsRecovery = 0)
        {
            var assetValue = note.Signal == SignalTypeEnum.Entry ?
                note.Asset.PurchasePrice :
                note.Asset.SellingPrice ?? 0;

            var assetValueTaxes = assetValue;

            // Valor total + impostos quando for produto
            if (note.Asset.Type == AssetsTypeEnum.Products)
                assetValueTaxes = assetValue - icmsRecovery ?? 0;

            // Debita na conta
            var debitRelease = new Releases
            {
                AccountId = note.Asset.AccountId,
                TotalAmount = assetValueTaxes,
                Type = FactType.Debit
            };

            _releasesService.Create(debitRelease);

            // Credita na conta de contra partida
            var creditRelease = new Releases
            {
                AccountId = note.Asset.Account.MatchAccountId ?? 1,
                TotalAmount = assetValue,
                Type = FactType.Credit
            };

            _releasesService.Create(creditRelease);
        }
    }
}
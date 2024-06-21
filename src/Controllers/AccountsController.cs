using Accounting.Project.src.Controllers.Base;
using Accounting.Project.src.Entities;
using Accounting.Project.src.Infra.Responses;
using Accounting.Project.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Project.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : AppControllerBase
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(
            IAccountsService accountsService
        )
        {
            _accountsService = accountsService;
        }

        [HttpGet]
        public ResponseBody Get()
        {
            return _accountsService.GetAll();
        }

        [HttpGet("GetByFilters")]
        public List<Accounts> GetByFilters(string filters)
        {
            return _accountsService.GetByFilters(filters);
        }

        [HttpGet("GetOptions")]
        public ResponseBody GetOptions()
        {
            return _accountsService
                .GetOptions();
        }

        [HttpPost]
        public ResponseBody Create([FromBody] Accounts entity)
        {
            return _accountsService.Create(entity);
        }

        [HttpPut]
        public ResponseBody Update([FromBody] Accounts entity)
        {
            return _accountsService.Update(entity);
        }

        [HttpDelete("{id}")]
        public ResponseBody Delete(long id)
        {
            return _accountsService.Delete(id);
        }
    }
}
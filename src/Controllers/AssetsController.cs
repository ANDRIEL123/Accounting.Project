using Accounting.Project.src.Controllers.Base;
using Accounting.Project.src.Entities;
using Accounting.Project.src.Infra.Responses;
using Accounting.Project.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Project.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetsController : AppControllerBase
    {
        private readonly IAssetsService _assetsService;

        public AssetsController(
            IAssetsService itemsService
        )
        {
            _assetsService = itemsService;
        }

        [HttpGet]
        public ResponseBody Get()
        {
            return _assetsService.GetAll();
        }

        [HttpGet("GetByFilters")]
        public List<Assets> GetByFilters(string filters)
        {
            return _assetsService.GetByFilters(filters);
        }

        [HttpGet("GetOptions")]
        public ResponseBody GetOptions()
        {
            return _assetsService
                .GetOptions();
        }

        [HttpPost]
        public ResponseBody Create([FromBody] Assets entity)
        {
            return _assetsService.Create(entity);
        }

        [HttpPut]
        public ResponseBody Update([FromBody] Assets entity)
        {
            return _assetsService.Update(entity);
        }

        [HttpDelete("{id}")]
        public ResponseBody Delete(long id)
        {
            return _assetsService.Delete(id);
        }
    }
}
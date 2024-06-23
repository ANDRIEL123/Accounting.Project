using Accounting.Project.src.Controllers.Base;
using Accounting.Project.src.Entities;
using Accounting.Project.src.Infra.Responses;
using Accounting.Project.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Project.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReleasesController : AppControllerBase
    {
        private readonly IReleasesService _releasesService;

        public ReleasesController(
            IReleasesService releasesService
        )
        {
            _releasesService = releasesService;
        }

        [HttpGet]
        public ResponseBody Get()
        {
            return _releasesService.GetAll();
        }

        [HttpGet("GetByFilters")]
        public List<Releases> GetByFilters(string filters)
        {
            return _releasesService.GetByFilters(filters);
        }

        [HttpGet("GetPatrimonyBalance")]
        public object GetPatrimonyBalance()
        {
            return _releasesService.PatrimonyBalance();
        }

        [HttpPost]
        public ResponseBody Create([FromBody] Releases entity)
        {
            return _releasesService.Create(entity);
        }

        [HttpPut]
        public ResponseBody Update([FromBody] Releases entity)
        {
            return _releasesService.Update(entity);
        }

        [HttpDelete("{id}")]
        public ResponseBody Delete(long id)
        {
            return _releasesService.Delete(id);
        }
    }
}
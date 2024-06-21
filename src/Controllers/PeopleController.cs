using Accounting.Project.src.Controllers.Base;
using Accounting.Project.src.Entities;
using Accounting.Project.src.Infra.Responses;
using Accounting.Project.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Project.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : AppControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(
            IPeopleService PeopleService
        )
        {
            _peopleService = PeopleService;
        }

        [HttpGet]
        public ResponseBody Get()
        {
            return _peopleService.GetAll();
        }

        [HttpGet("GetByFilters")]
        public List<People> GetByFilters(string filters)
        {
            return _peopleService.GetByFilters(filters);
        }

        [HttpGet("GetOptions")]
        public ResponseBody GetOptions()
        {
            return _peopleService
                .GetOptions();
        }

        [HttpPost]
        public ResponseBody Create([FromBody] People entity)
        {
            return _peopleService.Create(entity);
        }

        [HttpPut]
        public ResponseBody Update([FromBody] People entity)
        {
            return _peopleService.Update(entity);
        }

        [HttpDelete("{id}")]
        public ResponseBody Delete(long id)
        {
            return _peopleService.Delete(id);
        }
    }
}
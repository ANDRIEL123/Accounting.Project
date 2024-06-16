using Child.Growth.src.Controllers.Base;
using Child.Growth.src.Entities;
using Child.Growth.src.Infra.Responses;
using Child.Growth.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Child.Growth.src.Controllers
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
            var PeopleByFilter = _peopleService.GetByFilters(filters);

            return PeopleByFilter;
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
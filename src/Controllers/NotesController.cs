using Accounting.Project.src.Controllers.Base;
using Accounting.Project.src.Entities;
using Accounting.Project.src.Infra.Responses;
using Accounting.Project.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Project.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : AppControllerBase
    {
        private readonly INotesService _notesService;

        public NotesController(
            INotesService notesService
        )
        {
            _notesService = notesService;
        }

        [HttpGet]
        public ResponseBody Get()
        {
            return _notesService.GetAll();
        }

        [HttpGet("GetByFilters")]
        public List<Notes> GetByFilters(string filters)
        {
            return _notesService.GetByFilters(filters); ;
        }

        [HttpPost]
        public ResponseBody Create([FromBody] Notes entity)
        {
            return _notesService.Create(entity);
        }

        [HttpPut]
        public ResponseBody Update([FromBody] Notes entity)
        {
            return _notesService.Update(entity);
        }

        [HttpDelete("{id}")]
        public ResponseBody Delete(long id)
        {
            return _notesService.Delete(id);
        }
    }
}
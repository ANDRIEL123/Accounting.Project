using Child.Growth.src.Controllers.Base;
using Child.Growth.src.Entities;
using Child.Growth.src.Infra.Responses;
using Child.Growth.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Child.Growth.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : AppControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(
            IProductsService ProductsService
        )
        {
            _productsService = ProductsService;
        }

        [HttpGet]
        public ResponseBody Get()
        {
            return _productsService.GetAll();
        }

        [HttpGet("GetByFilters")]
        public List<Products> GetByFilters(string filters)
        {
            var ProductsByFilter = _productsService.GetByFilters(filters);

            return ProductsByFilter;
        }

        [HttpPost]
        public ResponseBody Create([FromBody] Products entity)
        {
            return _productsService.Create(entity);
        }

        [HttpPut]
        public ResponseBody Update([FromBody] Products entity)
        {
            return _productsService.Update(entity);
        }

        [HttpDelete("{id}")]
        public ResponseBody Delete(long id)
        {
            return _productsService.Delete(id);
        }
    }
}
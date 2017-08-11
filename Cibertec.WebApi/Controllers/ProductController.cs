using Cibertec.Models;
using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Routing;

namespace Cibertec.WebApi.Controllers
{
    [Route("product")]
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork unit): base(unit)
        {

        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_unit.Products.GetAll());
        }

        [HttpGet]
        [Route("listPaginated")]
        public IActionResult List(int page, int pageSize)
        {
            int startRow = ((page - 1) * pageSize) + 1;
            int endRow = page * pageSize;

            return Ok(_unit.Products.ListProductPaginated(startRow, endRow));
        }

        [HttpGet]
        [Route("count")]
        public IActionResult TotalRows()
        {
            return Ok(_unit.Products.TotalRows());
        }

        [HttpPost]
        public IActionResult Create([FromBody] product product)
        {
            return Ok(_unit.Products.Insert(product));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id) {
            if (id <= 0) return BadRequest();
            return Ok(_unit.Products.GetEntityById(id));
        }

        [HttpPut]
        public IActionResult Put([FromBody] product product)
        {
            _unit.Products.Update(product);
            return Ok(new { status = true });
        }
    }
}
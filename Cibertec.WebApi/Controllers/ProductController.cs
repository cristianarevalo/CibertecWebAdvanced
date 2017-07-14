using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;

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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cibertec.Models;
using Cibertec.UnitOfWork;

namespace Cibertec.Controllers
{
    public class OrderController : Controller
    {
        //private readonly NorthwindDbContext _db;
        //public OrderController(NorthwindDbContext db)
        //{
        //    _db = db;
        //}

        private readonly IUnitOfWork _unit;
        public OrderController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View(_unit.Orders.GetAll());
        }

        public IActionResult Detail()
        {
            return View(_unit.Orders.SearchByOrderNumber("542378"));
        }
    }
}
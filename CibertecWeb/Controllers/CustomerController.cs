using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cibertec.Models;
using Cibertec.UnitOfWork;
using Cibertec.Web.Filter;

namespace Cibertec.Controllers
{
    [ExceptionLoggerFilter]
    public class CustomerController : Controller
    {
        ////readonly: solo puede ser asigna en el contructor
        //private readonly NorthwindDbContext _db;
        //public CustomerController(NorthwindDbContext db) {
        //    _db = db;
        //}

        //public IActionResult Index()
        //{
        //    return View(_db.Customers);
        //}

        //trabajando con el Unit of Work
        private readonly IUnitOfWork _unit;
        public CustomerController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View(_unit.Customers.GetAll());
        }

        public IActionResult Detail()
        {
            return View(_unit.Customers.SearchByNames("Maria", "Anders"));
        }

    }
}
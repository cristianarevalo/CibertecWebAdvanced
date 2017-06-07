using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CibertecWeb.Models;

namespace CibertecWeb.Controllers
{
    public class CustomerController : Controller
    {
        //readonly: solo puede ser asigna en el contructor
        private readonly NorthwindDbContext _db;
        public CustomerController(NorthwindDbContext db) {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Customers);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CibertecWeb.Models;

namespace CibertecWeb.Controllers
{
    public class SupplierController : Controller
    {
        private readonly NorthwindDbContext _db;

        public SupplierController(NorthwindDbContext db) {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Suppliers);
        }
    }
}
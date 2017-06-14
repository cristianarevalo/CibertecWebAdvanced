using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cibertec.Web.Filter;

namespace Cibertec.Controllers
{
    [ExceptionLoggerFilter]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        //enrutamiento por notacion
        [Route("home/issue")]
        public ActionResult CreateIssue()
        {
            throw new Exception("New error for demostration");
        }
        
    }
}

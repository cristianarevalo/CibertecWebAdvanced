﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cibertec.Angular.Code;
using Microsoft.Extensions.Options;

namespace Cibertec.Angular.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConfigurationFile _config;
        public HomeController(IOptions<ConfigurationFile> config)
        {
            _config = config.Value;
        }

        public IActionResult Index()
        {
            ViewBag.WebApiUrl = _config.WebApiUrl;
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
    }
}

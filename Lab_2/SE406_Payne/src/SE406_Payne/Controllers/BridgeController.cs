﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Payne.Controllers
{
    public class BridgeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Title"] = "Bridge";
            ViewData["Message"] = "This is the Bridge controller page";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

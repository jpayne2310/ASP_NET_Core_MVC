using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Payne.Controllers
{
    public class CountyController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            CountyViewModel countiesVM = new CountyViewModel();
            using (var db = new CountyDBContext())
            {
                countiesVM.CountyList = db.Counties.ToList();
                countiesVM.NewCounty = new County();
            }

            return View(countiesVM);
        }

        [HttpPost]
        public IActionResult Index(CountyViewModel countyVM)
        {
            using (var db = new CountyDBContext())
            {
                db.Counties.Add(countyVM.NewCounty);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }
}

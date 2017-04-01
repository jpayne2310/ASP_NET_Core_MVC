using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        //inserts a new county
        [HttpPost]
        public IActionResult Index(CountyViewModel countyAdd)
        {
            if (ModelState.IsValid)
            {
                using (var db = new CountyDBContext())
                {
                    db.Counties.Add(countyAdd.NewCounty);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //Get Filled in Form
        public IActionResult Edit(Guid id)
        {
            //create an instance of the view model
            CountyViewModel countiesVM = new CountyViewModel();
            using (CountyDBContext db = new CountyDBContext())
            {
                //find id location in database
                countiesVM.NewCounty = db.Counties.Where(
                    e => e.CountyId == id).SingleOrDefault();

                //return the view model
                return View(countiesVM);
            }
        }

        //POST define edit action
        [HttpPost]
        public IActionResult Edit(CountyViewModel obj)
        {
            //check for valid model
            if (ModelState.IsValid)
            {
                using (CountyDBContext db = new CountyDBContext())
                {
                    //object for view model
                    County e = obj.NewCounty;
                    //retrieve primary key/id from route data
                    e.CountyId = Guid.Parse(RouteData.Values["id"].ToString());
                    //update record status
                    db.Entry(e).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}

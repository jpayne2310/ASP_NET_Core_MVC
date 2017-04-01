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
    public class FunctionalClassController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            FunctionalClassViewModel functionalClassVM = new FunctionalClassViewModel();
            using (var db = new FunctionalClassDBContext())
            {
                functionalClassVM.FunctionalClassList = db.FunctionalClasses.ToList();
                functionalClassVM.NewFunctionalClass = new FunctionalClass();
            }

            return View(functionalClassVM);
        }

        //add a new functional class
        [HttpPost]
        public IActionResult Index(FunctionalClassViewModel functionalClassAdd)
        {
            if (ModelState.IsValid)
            {
                using (var db = new FunctionalClassDBContext())
                {
                    db.FunctionalClasses.Add(functionalClassAdd.NewFunctionalClass);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //Get Fill Form
        public IActionResult Edit(Guid id)
        {
            //created a new instance of the view model 
            FunctionalClassViewModel fClassVM = new FunctionalClassViewModel();
            using (FunctionalClassDBContext db = new FunctionalClassDBContext())
            {
                //find id location in database
                fClassVM.NewFunctionalClass = db.FunctionalClasses.Where(
                    e => e.FunctionalClassId == id).SingleOrDefault();

                //return view model
                return View(fClassVM);
            }
        }

        //POST define edit action
        [HttpPost]
        public IActionResult Edit (FunctionalClassViewModel obj)
        {
            //check for valid model
            if (ModelState.IsValid)
            {
                using (FunctionalClassDBContext db = new FunctionalClassDBContext())
                {
                    //object for view model
                    FunctionalClass fc = obj.NewFunctionalClass;
                    //retrieve primary key/id from route data
                    fc.FunctionalClassId = Guid.Parse(RouteData.Values["id"].ToString());
                    //update record status
                    db.Entry(fc).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}

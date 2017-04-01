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
        public IActionResult Edit(FunctionalClassViewModel obj)
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

        //delete an entry
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            FunctionalClassViewModel fClassVm = new FunctionalClassViewModel();
            using (FunctionalClassDBContext db = new FunctionalClassDBContext())
            {
                using (var dbB = new BridgeDBContext())
                {
                    BridgeViewModel bridgeVm = new BridgeViewModel();
                    bridgeVm.BridgeList = dbB.Bridges.ToList();
                    bridgeVm.NewBridge = dbB.Bridges.Where(
                    fc => fc.FunctionalClassId == id).FirstOrDefault();
                    if (bridgeVm.NewBridge == null)
                    {
                        fClassVm.NewFunctionalClass = new FunctionalClass();
                        //retrieve info from route data
                        fClassVm.NewFunctionalClass.FunctionalClassId =
                            Guid.Parse(RouteData.Values["id"].ToString());
                        //update record status
                        db.Entry(fClassVm.NewFunctionalClass).State = EntityState.Deleted;
                        db.SaveChanges();
                        TempData["ResultMessage"] = "Functional Class deleted";
                    }
                    else
                    {
                        TempData["ResultMessage"] =
                            "This Functional Class has dependencies, cannot delete!";
                    }
                }
            }
            return RedirectToAction("Index");
        }

    }
}

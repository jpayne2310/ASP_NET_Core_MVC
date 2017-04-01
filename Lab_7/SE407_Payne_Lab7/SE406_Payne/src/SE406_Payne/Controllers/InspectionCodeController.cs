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
    public class InspectionCodeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectionCodeViewModel inspectionCodeVM = new InspectionCodeViewModel();
            using (var db = new InspectionCodesDBContext())
            {
                inspectionCodeVM.InspectionCodeList = db.InspectionCodes.ToList();
                inspectionCodeVM.NewInspectionCode = new InspectionCode();
            }

            return View(inspectionCodeVM);
        }

        //insert a new inspection code
        [HttpPost]
        public IActionResult Index(InspectionCodeViewModel inspectionCodeAdd)
        {
            if (ModelState.IsValid)
            {
                using (var db = new InspectionCodesDBContext())
                {
                    db.InspectionCodes.Add(inspectionCodeAdd.NewInspectionCode);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //Get Filled Form 
        public IActionResult Edit(Guid id)
        {
            //a new instance of the view model
            InspectionCodeViewModel iCodeVM = new InspectionCodeViewModel();
            using (InspectionCodesDBContext db = new InspectionCodesDBContext())
            {
                //find id location in database
                iCodeVM.NewInspectionCode = db.InspectionCodes.Where(
                    e => e.InspectionCodeId == id).SingleOrDefault();

                //return view model
                return View(iCodeVM);
            }
        }

        //POST define edit action
        [HttpPost]
        public IActionResult Edit(InspectionCodeViewModel obj)
        {
            using (InspectionCodesDBContext db = new InspectionCodesDBContext())
            {
                //check for valid model
                if (ModelState.IsValid)
                {
                    //object for view model
                    InspectionCode ic = obj.NewInspectionCode;
                    //retrieve primary key/id from route data
                    ic.InspectionCodeId = Guid.Parse(RouteData.Values["id"].ToString());
                    //update record status
                    db.Entry(ic).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        

    }
}

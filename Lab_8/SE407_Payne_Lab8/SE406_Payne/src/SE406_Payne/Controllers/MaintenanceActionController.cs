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
    public class MaintenanceActionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            MaintenanceActionViewModel maintenanceActionVM = new MaintenanceActionViewModel();
            using (var db = new MaintenanceActionDBContext())
            {
                maintenanceActionVM.MaintenanceActionList = db.MaintenanceActions.ToList();
                maintenanceActionVM.NewMaintenanceAction = new MaintenanceAction();
            }

            return View(maintenanceActionVM);
        }

        //insert new maintenance actions
        [HttpPost]
        public IActionResult Index(MaintenanceActionViewModel maintenanceActionAdd)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MaintenanceActionDBContext())
                {
                    db.MaintenanceActions.Add(maintenanceActionAdd.NewMaintenanceAction);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //GET Filled in Form
        public IActionResult Edit(Guid id)
        {
            //a new instance of the view model
            MaintenanceActionViewModel mActionVM = new MaintenanceActionViewModel();
            using (MaintenanceActionDBContext db = new MaintenanceActionDBContext())
            {
                //find id location in databased
                mActionVM.NewMaintenanceAction = db.MaintenanceActions.Where(
                    e => e.MaintenanceActionId == id).SingleOrDefault();

                //return view model
                return View(mActionVM);
            }
        }

        //POST define edit action
        [HttpPost]
        public IActionResult Edit(MaintenanceActionViewModel obj)
        {
            //check for valid view model
            if (ModelState.IsValid)
            {
                using (MaintenanceActionDBContext db = new MaintenanceActionDBContext())
                {
                    //object for view model
                    MaintenanceAction ma = obj.NewMaintenanceAction;
                    //retrieve primary key/id from route data
                    ma.MaintenanceActionId = Guid.Parse(RouteData.Values["id"].ToString());
                    //update record status
                    db.Entry(ma).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //delete an entry
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MaintenanceActionViewModel mActions = new MaintenanceActionViewModel();
            using (MaintenanceActionDBContext db = new MaintenanceActionDBContext())
            {
                using (var dbMA = new MaintenanceRecordDBContext())
                {
                    MaintenanceRecordViewModel mRecordVm = new MaintenanceRecordViewModel();
                    mRecordVm.MaintenanceRecordList = dbMA.MaintenanceRecords.ToList();
                    mRecordVm.NewMaintenanceRecord = dbMA.MaintenanceRecords.Where(
                    mr => mr.MaintenanceActionId == id).FirstOrDefault();
                    //create an instance of the view model
                    if (mRecordVm.NewMaintenanceRecord == null)
                    {
                        mActions.NewMaintenanceAction = new MaintenanceAction();
                        //retrieve info from route data
                        mActions.NewMaintenanceAction.MaintenanceActionId =
                            Guid.Parse(RouteData.Values["id"].ToString());
                        //change record status
                        db.Entry(mActions.NewMaintenanceAction).State = EntityState.Deleted;
                        db.SaveChanges();
                        TempData["ResultMessage"] = "Maintenance Action deleted";
                    }
                    else
                    {
                        TempData["ResultMessage"] = "This Maintenance Action has depentencies, unable to Delete!";
                    }
                }
            }
            return RedirectToAction("Index");
        }

    }
}

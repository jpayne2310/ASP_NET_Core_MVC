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
    public class MaintenanceRecordController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            MaintenanceRecordViewModel maintenanceRecordVM = new MaintenanceRecordViewModel();
            using (var db = new MaintenanceRecordDBContext())
            {
                maintenanceRecordVM.MaintenanceRecordList = db.MaintenanceRecords.ToList();
                maintenanceRecordVM.NewMaintenanceRecord = new MaintenanceRecord();
                maintenanceRecordVM.Inspectors = GetInspectorsDDL();
                maintenanceRecordVM.MaintenanceActions = GetMaintenanceActionsDDL();
            }

            return View(maintenanceRecordVM);
        }

        //insert new maintenance records
        [HttpPost]
        public IActionResult Index(MaintenanceRecordViewModel maintenanceRecordAdd)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MaintenanceRecordDBContext())
                {
                    db.MaintenanceRecords.Add(maintenanceRecordAdd.NewMaintenanceRecord);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //GET Filled in Form
        public IActionResult Edit(Guid id)
        {
            //a new instance of the view model
            MaintenanceRecordViewModel mRecordVM = new MaintenanceRecordViewModel();
            using (MaintenanceRecordDBContext db = new MaintenanceRecordDBContext())
            {
                //find id location in database
                mRecordVM.NewMaintenanceRecord = db.MaintenanceRecords.Where(
                    e => e.MaintenanceRecordId == id).SingleOrDefault();
                //fill in inspector drop down
                mRecordVM.Inspectors = GetInspectorsDDL();
                //fill in maintenance actions drop down
                mRecordVM.MaintenanceActions = GetMaintenanceActionsDDL();

                //return view model
                return View(mRecordVM);
            }
        }

        //POST define edit action
        [HttpPost]
        public IActionResult Edit(MaintenanceRecordViewModel obj)
        {
            //check for valid view model
            if(ModelState.IsValid)
            {
                using (MaintenanceRecordDBContext db = new MaintenanceRecordDBContext())
                {
                    //object for view model
                    MaintenanceRecord mr = obj.NewMaintenanceRecord;
                    //retrieve primary key/id from route data
                    mr.MaintenanceRecordId = Guid.Parse(RouteData.Values["id"].ToString());
                    //update record status
                    db.Entry(mr).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //delete an entry
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MaintenanceRecordViewModel mRecordsVm = new MaintenanceRecordViewModel();
            using (MaintenanceRecordDBContext db = new MaintenanceRecordDBContext())
            {
                //create an instance of the view model
                mRecordsVm.NewMaintenanceRecord = new MaintenanceRecord();
                //find id
                mRecordsVm.NewMaintenanceRecord.MaintenanceRecordId =
                    Guid.Parse(RouteData.Values["id"].ToString());
                //update record Status
                db.Entry(mRecordsVm.NewMaintenanceRecord).State = EntityState.Deleted;
                db.SaveChanges();
                TempData["ResultMessage"] = "The Maintenance Record was Deleted.";
            }
            return RedirectToAction("Index");
        }

        private static List<SelectListItem> GetInspectorsDDL()
        {
            List<SelectListItem> inspect = new List<SelectListItem>();
            InspectorViewModel ivm = new InspectorViewModel();
            using (var db = new InspectorDBContext())
            {
                ivm.InspectorList = db.Inspectors.ToList();
            }
            foreach (Inspector i in ivm.InspectorList)
            {
                inspect.Add(new SelectListItem
                    {
                        Text = i.InspectorFirst + " " + i.InspectorLast,
                        Value = i.InspectorId.ToString()
                });
            }
            return inspect;
        }

        private static List<SelectListItem> GetMaintenanceActionsDDL()
        {
            List<SelectListItem> action = new List<SelectListItem>();
            MaintenanceActionViewModel mavm = new MaintenanceActionViewModel();
            using (var db = new MaintenanceActionDBContext())
            {
                mavm.MaintenanceActionList = db.MaintenanceActions.ToList();
            }
            foreach (MaintenanceAction ma in mavm.MaintenanceActionList)
            {
                action.Add(new SelectListItem
                {
                    Text = ma.MaintenanceActionName,
                    Value = ma.MaintenanceActionId.ToString()
                });
            }
            return action;
        }

    }
}

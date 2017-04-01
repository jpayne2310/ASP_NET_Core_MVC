using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            using (var db = new MaintenanceActionsDBContext())
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

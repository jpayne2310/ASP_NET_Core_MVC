using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;

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
            }

            return View(maintenanceRecordVM);
        }

        [HttpPost]
        public IActionResult Index(MaintenanceRecordViewModel maintenanceRecordVM)
        {
            using (var db = new MaintenanceRecordDBContext())
            {
                db.MaintenanceRecords.Add(maintenanceRecordVM.NewMaintenanceRecord);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }
}

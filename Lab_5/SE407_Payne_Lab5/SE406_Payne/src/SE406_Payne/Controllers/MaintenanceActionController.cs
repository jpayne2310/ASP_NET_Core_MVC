using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Payne.Controllers
{
    public class MaintenanceActionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            MaintenanceActionViewModel maintenanceActionVM = new MaintenanceActionViewModel();
            using (var db = new MaintenanceActionsDBContext())
            {
                maintenanceActionVM.MaintenanceActionList = db.MaintenanceActions.ToList();
                maintenanceActionVM.NewMaintenanceAction = new MaintenanceAction();
            }

            return View(maintenanceActionVM);
        }

        [HttpPost]
        public IActionResult Index(MaintenanceActionViewModel maintenanceActionVM)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MaintenanceActionsDBContext())
                {
                    db.MaintenanceActions.Add(maintenanceActionVM.NewMaintenanceAction);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}

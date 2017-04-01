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
            if(ModelState.IsValid)
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

    }
}

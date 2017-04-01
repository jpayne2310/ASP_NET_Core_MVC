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
    public class InspectorController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectorViewModel inspectorVM = new InspectorViewModel();
            using (var db = new InspectorDBContext())
            {
                inspectorVM.InspectorList = db.Inspectors.ToList();
                inspectorVM.NewInspector = new Inspector();
            }

            return View(inspectorVM);
        }

        //insert new inspectors
        [HttpPost]
        public IActionResult Index(InspectorViewModel inspectorAdd)
        {
            if (ModelState.IsValid)
            {
                using (var db = new InspectorDBContext())
                {
                    db.Inspectors.Add(inspectorAdd.NewInspector);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //GET Filled in Form
        public IActionResult Edit(Guid id)
        {
            //a new instance of the view model
            InspectorViewModel inspVM = new InspectorViewModel();
            using (InspectorDBContext db = new InspectorDBContext())
            {
                inspVM.NewInspector = db.Inspectors.Where(
                    e => e.InspectorId == id).SingleOrDefault();

                //return view model
                return View(inspVM);
            }
        }

        //POST define edit action
        [HttpPost]
        public IActionResult Edit(InspectorViewModel obj)
        {
            //check for valid model
            if (ModelState.IsValid)
            {
                using (InspectorDBContext db = new InspectorDBContext())
                {
                    //object for view model
                    Inspector i = obj.NewInspector;
                    //retrieve primary key/id from route data
                    i.InspectorId = Guid.Parse(RouteData.Values["id"].ToString());
                    //update record status
                    db.Entry(i).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}

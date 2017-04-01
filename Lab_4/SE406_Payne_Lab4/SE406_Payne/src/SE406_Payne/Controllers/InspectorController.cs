using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Payne.Controllers
{
    public class InspectorController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectorViewModel inspectorVM = new InspectorViewModel();
            using (var db = new InspectorsDBContext())
            {
                inspectorVM.InspectorList = db.Inspectors.ToList();
                inspectorVM.NewInspector = new Inspector();
            }

            return View(inspectorVM);
        }

        [HttpPost]
        public IActionResult Index(InspectorViewModel inspectorVM)
        {
            using (var db = new InspectorsDBContext())
            {
                db.Inspectors.Add(inspectorVM.NewInspector);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }
}

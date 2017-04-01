using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Payne.Controllers
{
    public class InspectionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectionViewModel inspectionVM = new InspectionViewModel();
            using (var db = new InspectionsDBContext())
            {
                inspectionVM.InspectionList = db.Inspections.ToList();
                inspectionVM.NewInspection = new Inspection();
            }

            return View(inspectionVM);
        }

        [HttpPost]
        public IActionResult Index(InspectionViewModel inspectionVM)
        {
            using (var db = new InspectionsDBContext())
            {
                db.Inspections.Add(inspectionVM.NewInspection);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }
}

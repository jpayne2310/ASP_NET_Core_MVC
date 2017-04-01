using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;

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

        [HttpPost]
        public IActionResult Index(InspectionCodeViewModel inspectionCodeVM)
        {
            if (ModelState.IsValid)
            {
                using (var db = new InspectionCodesDBContext())
                {
                    db.InspectionCodes.Add(inspectionCodeVM.NewInspectionCode);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Payne.Controllers
{
    public class FunctionalClassController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            FunctionalClassViewModel functionalClassVM = new FunctionalClassViewModel();
            using (var db = new FunctionalClassDBContext())
            {
                functionalClassVM.FunctionalClassList = db.FunctionalClasses.ToList();
                functionalClassVM.NewFunctionalClass = new FunctionalClass();
            }

            return View(functionalClassVM);
        }

        [HttpPost]
        public IActionResult Index(FunctionalClassViewModel functionalClassVM)
        {
            if (ModelState.IsValid)
            {
                using (var db = new FunctionalClassDBContext())
                {
                    db.FunctionalClasses.Add(functionalClassVM.NewFunctionalClass);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Payne.Controllers
{
    public class MaterialDesignController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            MaterialDesignViewModel materialDesignVM = new MaterialDesignViewModel();
            using (var db = new MaterialDesignDBContext())
            {
                materialDesignVM.MaterialDesignList = db.MaterialDesigns.ToList();
                materialDesignVM.NewMaterialDesign = new MaterialDesign();
            }

            return View(materialDesignVM);
        }

        [HttpPost]
        public IActionResult Index(MaterialDesignViewModel materialDesignVM)
        {
            using (var db = new MaterialDesignDBContext())
            {
                if (ModelState.IsValid)
                {
                    db.MaterialDesigns.Add(materialDesignVM.NewMaterialDesign);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}

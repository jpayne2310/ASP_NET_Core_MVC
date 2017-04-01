using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Payne.Controllers
{
    public class ConstructionDesignController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ConstructionDesignViewModel constructionDesignVM = new ConstructionDesignViewModel();
            using (var db = new ConstructionDesignDBContext())
            {
                constructionDesignVM.ConstructionDesignList = db.ConstructionDesigns.ToList();
                constructionDesignVM.NewConstructionDesign = new ConstructionDesign();
            }

            return View(constructionDesignVM);
        }

        [HttpPost]
        public IActionResult Index(ConstructionDesignViewModel constructionDesignVM)
        {
            using (var db = new ConstructionDesignDBContext())
            {
                db.ConstructionDesigns.Add(constructionDesignVM.NewConstructionDesign);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }
}

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

        //insert new construction designs
        [HttpPost]
        public IActionResult Index(ConstructionDesignViewModel constructionDesignAdd)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ConstructionDesignDBContext())
                {
                    db.ConstructionDesigns.Add(constructionDesignAdd.NewConstructionDesign);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //Get Fill Form
        public IActionResult Edit(Guid id)
        {
            ConstructionDesignViewModel cDesignVM = new ConstructionDesignViewModel();
            using (ConstructionDesignDBContext db = new ConstructionDesignDBContext())
            {
                //find id passed location in database
                cDesignVM.NewConstructionDesign = db.ConstructionDesigns.Where(
                    e => e.ConstructionDesignId == id).SingleOrDefault();

                //return view model
                return View(cDesignVM);
            }
        }

        //define edit action
        [HttpPost]
        public IActionResult Edit(ConstructionDesignViewModel obj)
        {
            //check for valid model
            if(ModelState.IsValid)
            {
                using (ConstructionDesignDBContext db = new ConstructionDesignDBContext())
                {
                    //instantiate object from view model
                    ConstructionDesign c = obj.NewConstructionDesign;
                    //retrieve primary key/id from route data
                    c.ConstructionDesignId = Guid.Parse(RouteData.Values["id"].ToString());
                    //update record status
                    db.Entry(c).State = EntityState.Modified;
                    //persist changes
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}

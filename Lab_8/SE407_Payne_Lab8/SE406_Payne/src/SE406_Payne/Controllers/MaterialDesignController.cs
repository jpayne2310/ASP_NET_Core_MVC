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

        //insert new material Designs
        [HttpPost]
        public IActionResult Index(MaterialDesignViewModel materialDesignAdd)
        {
            using (var db = new MaterialDesignDBContext())
            {
                if (ModelState.IsValid)
                {
                    db.MaterialDesigns.Add(materialDesignAdd.NewMaterialDesign);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //GET Filled in Form
        public IActionResult Edit(Guid id)
        {
            //a new instance of the view model
            MaterialDesignViewModel mDesign = new MaterialDesignViewModel();
            using (MaterialDesignDBContext db = new MaterialDesignDBContext())
            {
                //find id location in database
                mDesign.NewMaterialDesign = db.MaterialDesigns.Where(
                    e => e.MaterialDesignId == id).SingleOrDefault();

                //return view model
                return View(mDesign);
            }
        }

        //POST Define edit action
        [HttpPost]
        public IActionResult Edit(MaterialDesignViewModel obj)
        {
            //check for valid model
            if (ModelState.IsValid)
            {
                using (MaterialDesignDBContext db = new MaterialDesignDBContext())
                {
                    //object for view model
                    MaterialDesign md = obj.NewMaterialDesign;
                    //retrieve primary key/id from route data
                    md.MaterialDesignId = Guid.Parse(RouteData.Values["id"].ToString());
                    //update record status
                    db.Entry(md).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //delete an entry
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MaterialDesignViewModel mDesignVm = new MaterialDesignViewModel();
            using (MaterialDesignDBContext db = new MaterialDesignDBContext())
            {

                using (var dbB = new BridgeDBContext())
                {
                    BridgeViewModel bridgeVm = new BridgeViewModel();
                    bridgeVm.BridgeList = dbB.Bridges.ToList();
                    bridgeVm.NewBridge = dbB.Bridges.Where(
                    md => md.MaterialDesignId == id).FirstOrDefault();
                    if (bridgeVm.NewBridge == null)
                    {
                        mDesignVm.NewMaterialDesign = new MaterialDesign();
                        //find id in database
                        mDesignVm.NewMaterialDesign.MaterialDesignId =
                            Guid.Parse(RouteData.Values["id"].ToString());
                        //update recode state
                        db.Entry(mDesignVm.NewMaterialDesign).State = EntityState.Deleted;
                        db.SaveChanges();
                        TempData["ResultMessage"] = "Material Design deleted";
                    }
                    else
                    {
                        TempData["ResultMessage"] =
                            "This Material Design has dependencies, cannot delete!";
                    }
                }
            }
            return RedirectToAction("Index");
        }

    }
}

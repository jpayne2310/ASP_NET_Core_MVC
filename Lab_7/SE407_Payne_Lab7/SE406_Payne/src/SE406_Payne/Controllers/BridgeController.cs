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
    public class BridgeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            BridgeViewModel bridgeVM = new BridgeViewModel();
            using (var db = new BridgeDBContext())
            {
                bridgeVM.BridgeList = db.Bridges.ToList();
                bridgeVM.NewBridge = new Bridge();
                bridgeVM.MaterialDesigns = GetMaterialDesignsDDL();
                bridgeVM.ConstructionDesigns = GetConstructionDesignsDDL();
                bridgeVM.FunctionalClasses = GetFunctionalClassesDDL();
                bridgeVM.StatusCodes = GetStatusCodesDDL();
                bridgeVM.Counties = GetCountiesDDL();
            }

                return View(bridgeVM);
        }

        //insert new bridges
        [HttpPost]
        public IActionResult Index(BridgeViewModel bridgeVM)
        {
            if (ModelState.IsValid) 
            {
                using (var db = new BridgeDBContext())
                {
                    db.Bridges.Add(bridgeVM.NewBridge);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //GET Fill Form
        public IActionResult Edit(Guid id)
        {
            //create an instance of the view model
            BridgeViewModel bridgeVM = new BridgeViewModel();
            using (BridgeDBContext db = new BridgeDBContext())
            {
                //find id passed in location in the database
                bridgeVM.NewBridge = db.Bridges.Where(
                    e => e.Bridgeid == id).SingleOrDefault();
                //fill Material Designs drop down
                bridgeVM.MaterialDesigns = GetMaterialDesignsDDL();
                //fill Construction Designs drop down
                bridgeVM.ConstructionDesigns = GetConstructionDesignsDDL();
                //fill Functional Classes drop down
                bridgeVM.FunctionalClasses = GetFunctionalClassesDDL();
                //fill Status Codes drop down
                bridgeVM.StatusCodes = GetStatusCodesDDL();
                //fill Counties drop down
                bridgeVM.Counties = GetCountiesDDL();

                //return the view model
                return View(bridgeVM);
            }
        }

        //POST for edit action
        [HttpPost]
        public IActionResult Edit(BridgeViewModel obj)
        {
            //check for valid model state
            if(ModelState.IsValid)
            {
                using (BridgeDBContext db = new BridgeDBContext())
                {
                    //instance of object
                    Bridge b = obj.NewBridge;
                    //retrieve info from route data
                    b.Bridgeid = Guid.Parse(RouteData.Values["id"].ToString());
                    //update record state
                    db.Entry(b).State = EntityState.Modified;
                    //save changes
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        private static List<SelectListItem>GetMaterialDesignsDDL()
        {
            List<SelectListItem> material = new List<SelectListItem>();
            MaterialDesignViewModel mdvm = new MaterialDesignViewModel();
            using (var db = new MaterialDesignDBContext())
            {
                mdvm.MaterialDesignList = db.MaterialDesigns.ToList();
            }
            foreach(MaterialDesign m in mdvm.MaterialDesignList)
            {
                material.Add(new SelectListItem
                {
                    Text = m.MaterialDesignType,
                    Value = m.MaterialDesignId.ToString()
                });
            }
            return material;
        }

        private static List<SelectListItem>GetConstructionDesignsDDL()
        {
            List<SelectListItem> cDesign = new List<SelectListItem>();
            ConstructionDesignViewModel cdvm = new ConstructionDesignViewModel();
            using (var db = new ConstructionDesignDBContext())
            {
                cdvm.ConstructionDesignList = db.ConstructionDesigns.ToList();
            }
            foreach(ConstructionDesign c in cdvm.ConstructionDesignList)
            {
                cDesign.Add(new SelectListItem
                {
                    Text = c.ConstructionDesignType,
                    Value = c.ConstructionDesignId.ToString()
                });
            }
            return cDesign;
        }

        private static List<SelectListItem>GetFunctionalClassesDDL()
        {
            List<SelectListItem> fClass = new List<SelectListItem>();
            FunctionalClassViewModel fcvm = new FunctionalClassViewModel();
            using (var db = new FunctionalClassDBContext())
            {
                fcvm.FunctionalClassList = db.FunctionalClasses.ToList();
            }
            foreach(FunctionalClass f in fcvm.FunctionalClassList)
            {
                fClass.Add(new SelectListItem
                {
                    Text = f.FunctionalClassType,
                    Value = f.FunctionalClassId.ToString()
                });
            }
            return fClass;
        }

        private static List<SelectListItem> GetStatusCodesDDL()
        {
            List<SelectListItem> sCode = new List<SelectListItem>();
            StatusCodeViewModel scvm = new StatusCodeViewModel();
            using (var db = new StatusCodeDBContext())
            {
                scvm.StatusCodeList = db.StatusCodes.ToList();
            }
            foreach(StatusCode s in scvm.StatusCodeList)
            {
                sCode.Add(new SelectListItem
                {
                    Text = s.StatusName,
                    Value = s.StatusCodeId.ToString()
                });
            }
            return sCode;
        }

        private static List<SelectListItem> GetCountiesDDL()
        {
            List<SelectListItem> counties = new List<SelectListItem>();
            CountyViewModel cvm = new CountyViewModel();
            using (var db = new CountyDBContext())
            {
                cvm.CountyList = db.Counties.ToList();
            }
            foreach(County c in cvm.CountyList)
            {
                counties.Add(new SelectListItem
                {
                    Text = c.CountyName,
                    Value = c.CountyId.ToString()
                });
            }
            return counties;
        }
    }
}

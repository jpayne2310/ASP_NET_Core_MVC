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
    public class InspectionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            InspectionViewModel inspectionVM = new InspectionViewModel();
            using (var db = new InspectionDBContext())
            {
                inspectionVM.InspectionList = db.Inspections.ToList();
                inspectionVM.NewInspection = new Inspection();
                inspectionVM.Bridges = GetBridgesDDL();
                inspectionVM.Inspectors = GetInspectorsDDL();
                inspectionVM.DeckInspections = GetInspectionsDDL();
                inspectionVM.SuperInspections = GetInspectionsDDL();
                inspectionVM.SubInspections = GetInspectionsDDL();
            }

            return View(inspectionVM);
        }

        //insert new inspections
        [HttpPost]
        public IActionResult Index(InspectionViewModel inspectionVM)
        {
            if (ModelState.IsValid)               
            {
                using (var db = new InspectionDBContext())
                {
                    db.Inspections.Add(inspectionVM.NewInspection);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //GET Filled in Form
        public IActionResult Edit(Guid id)
        {
            //a new instance of the view model
            InspectionViewModel inspectVM = new InspectionViewModel();
            using (InspectionDBContext db = new InspectionDBContext())
            {
                //find id location in database
                inspectVM.NewInspection = db.Inspections.Where(
                    e => e.InspectionId == id).SingleOrDefault();
                //fill in bridgeid drop down
                inspectVM.Bridges = GetBridgesDDL();
                //fill in inspectors drop down
                inspectVM.Inspectors = GetInspectorsDDL();
                //fill in deck inspection drop down
                inspectVM.DeckInspections = GetInspectionsDDL();
                //fill in superstructure drop down
                inspectVM.SuperInspections = GetInspectionsDDL();
                //fill in substructure drop down
                inspectVM.SubInspections = GetInspectionsDDL();

                //return view model
                return View(inspectVM);
            }
        }

        //Post define edit action
        [HttpPost]
        public IActionResult Edit(InspectionViewModel obj)
        {
            //check fpr valid view model
            if (ModelState.IsValid)
            {
                using (InspectionDBContext db = new InspectionDBContext())
                {
                    //object for view model
                    Inspection i = obj.NewInspection;
                    //retrieve primary key/id from route data
                    i.InspectionId = Guid.Parse(RouteData.Values["id"].ToString());
                    //update record status
                    db.Entry(i).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //delete an entry
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            InspectionViewModel inspectVm = new InspectionViewModel();
            using (InspectionDBContext db = new InspectionDBContext())
            {
                //create an instance of the view model
                inspectVm.NewInspection = new Inspection();
                //retrieve info from route data
                inspectVm.NewInspection.InspectionId =
                    Guid.Parse(RouteData.Values["id"].ToString());
                //update record status
                db.Entry(inspectVm.NewInspection).State = EntityState.Deleted;
                db.SaveChanges();
                TempData["ResultMessage"] = " The Inspection has been deleted.";
            }
            return RedirectToAction("Index");
        }



        private static List<SelectListItem> GetBridgesDDL()
        {
            List<SelectListItem> bridge = new List<SelectListItem>();
            BridgeViewModel bvm = new BridgeViewModel();
            using (var db = new BridgeDBContext())
            {
                bvm.BridgeList = db.Bridges.ToList();
            }
            foreach (Bridge b in bvm.BridgeList)
            {
                bridge.Add(new SelectListItem
                {
                    Text = b.Location.ToString(),
                    Value = b.Bridgeid.ToString()
                });
            }
            return bridge;
        }

        private static List<SelectListItem> GetInspectorsDDL()
        {
            List<SelectListItem> inspector = new List<SelectListItem>();
            InspectorViewModel ivm = new InspectorViewModel();
            using (var db = new InspectorDBContext())
            {
                ivm.InspectorList = db.Inspectors.ToList();
            }
            foreach (Inspector i in ivm.InspectorList)
            {
                inspector.Add(new SelectListItem
                {
                    Text = i.InspectorFirst + " " + i.InspectorLast,
                    Value = i.InspectorId.ToString()
                });
            }
            return inspector;
        }

        private static List<SelectListItem> GetInspectionsDDL()
        {
            List<SelectListItem> deck = new List<SelectListItem>();
            InspectionCodeViewModel isvm = new InspectionCodeViewModel();
            using (var db = new InspectionCodesDBContext())
            {
                isvm.InspectionCodeList = db.InspectionCodes.ToList();
            }
            foreach (InspectionCode ip in isvm.InspectionCodeList)
            {
                deck.Add(new SelectListItem
                {
                    Text = ip.InspectionCodeName.ToString(),
                    Value = ip.InspectionCodeId.ToString()
                });
            }
            return deck;
        }
    }
}

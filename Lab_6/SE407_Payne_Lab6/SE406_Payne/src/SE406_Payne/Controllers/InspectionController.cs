using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                inspectionVM.Inspections = GetInspectionsDDDL();
                inspectionVM.Inspections = GetInspectionsSupDDL();
                inspectionVM.Inspections = GetInspectionsSubDDL();
            }

            return View(inspectionVM);
        }

        [HttpPost]
        public IActionResult Index(InspectionViewModel inspectionAdd)
        {
            if (ModelState.IsValid)               
            {
                using (var db = new InspectionDBContext())
                {
                    db.Inspections.Add(inspectionAdd.NewInspection);
                    db.SaveChanges();
                }
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
                    Text = b.Bridgeid.ToString()
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

        private static List<SelectListItem> GetInspectionsDDDL()
        {
            List<SelectListItem> deck = new List<SelectListItem>();
            InspectionViewModel isvm = new InspectionViewModel();
            using (var db = new InspectionDBContext())
            {
                isvm.InspectionList = db.Inspections.ToList();
            }
            foreach (Inspection ip in isvm.InspectionList)
            {
                deck.Add(new SelectListItem
                {
                    Text = ip.DeckInspectionCodeId.ToString()
                });
            }
            return deck;
        }

        private static List<SelectListItem> GetInspectionsSupDDL()
        {
            List<SelectListItem> super = new List<SelectListItem>();
            InspectionViewModel isvm2 = new InspectionViewModel();
            using (var db = new InspectionDBContext())
            {
                isvm2.InspectionList = db.Inspections.ToList();
            }
            foreach (Inspection ip2 in isvm2.InspectionList)
            {
                super.Add(new SelectListItem
                {
                    Text = ip2.SuperstructureInspectionCodeId.ToString()
                });
            }
            return super;
        }

        private static List<SelectListItem> GetInspectionsSubDDL()
        {
            List<SelectListItem> substruct = new List<SelectListItem>();
            InspectionViewModel isvm3 = new InspectionViewModel();
            using (var db = new InspectionDBContext())
            {
                isvm3.InspectionList = db.Inspections.ToList();
            }
            foreach (Inspection ip3 in isvm3.InspectionList)
            {
                substruct.Add(new SelectListItem
                {
                    Text = ip3.SubstructureInspectionCodeId.ToString()
                });
            }
            return substruct;
        }

    }
}

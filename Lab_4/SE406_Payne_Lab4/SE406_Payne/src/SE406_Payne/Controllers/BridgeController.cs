using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;
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
            }

                return View(bridgeVM);
        }

        [HttpPost]
        public IActionResult Index(BridgeViewModel bridgeVM)
        {
            using (var db = new BridgeDBContext())
            {
                db.Bridges.Add(bridgeVM.NewBridge);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}

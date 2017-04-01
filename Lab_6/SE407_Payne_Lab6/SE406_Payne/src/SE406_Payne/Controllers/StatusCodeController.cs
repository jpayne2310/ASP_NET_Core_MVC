using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE406_Payne.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE406_Payne.Controllers
{
    public class StatusCodeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            StatusCodeViewModel statusCodeVM = new StatusCodeViewModel();
            using (var db = new StatusCodeDBContext())
            {
                statusCodeVM.StatusCodeList = db.StatusCodes.ToList();
                statusCodeVM.NewStatusCode = new StatusCode();
            }

            return View(statusCodeVM);
        }

        [HttpPost]
        public IActionResult Index(StatusCodeViewModel statusCodeVM)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StatusCodeDBContext())
                {
                    db.StatusCodes.Add(statusCodeVM.NewStatusCode);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}

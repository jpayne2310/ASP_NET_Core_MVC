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

        //insert new status codes
        [HttpPost]
        public IActionResult Index(StatusCodeViewModel statusCodeAdd)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StatusCodeDBContext())
                {
                    db.StatusCodes.Add(statusCodeAdd.NewStatusCode);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //GET Filled in Form
        public IActionResult Edit(Guid id)
        {
            //a new instance of the view model
            StatusCodeViewModel sCodeVM = new StatusCodeViewModel();
            using (StatusCodeDBContext db = new StatusCodeDBContext())
            {
                //find id location in database
                sCodeVM.NewStatusCode = db.StatusCodes.Where(
                    e => e.StatusCodeId == id).SingleOrDefault();

                //return view model
                return View(sCodeVM);
            }
        }

        //POST define edit action
        [HttpPost]
        public IActionResult Edit(StatusCodeViewModel obj)
        {
            //check for valid model
            if(ModelState.IsValid)
            {
                using (StatusCodeDBContext db = new StatusCodeDBContext())
                {
                    //object for view model
                    StatusCode sc = obj.NewStatusCode;
                    //retrieve primary key/id from route data
                    sc.StatusCodeId = Guid.Parse(RouteData.Values["id"].ToString());
                    //update record status
                    db.Entry(sc).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}

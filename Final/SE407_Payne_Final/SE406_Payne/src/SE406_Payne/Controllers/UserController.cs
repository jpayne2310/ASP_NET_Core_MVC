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
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            UserViewModel userVM = new UserViewModel();
            using (var db = new UserDBContext())
            {
                userVM.UserList = db.Users.ToList();
                userVM.NewUser = new User();
            }
            return View(userVM);
        }

        //insert new user
        [HttpPost]
        public IActionResult Index(UserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                using (var db = new UserDBContext())
                {
                    db.Users.Add(userVM.NewUser);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //fill edit form
        public IActionResult Edit(Guid id)
        {
            //create an instance of the view model
            UserViewModel userVM = new UserViewModel();
            using (UserDBContext db = new UserDBContext())
            {
                //find id location in database
                userVM.NewUser = db.Users.Where(
                    u => u.UserID == id).SingleOrDefault();

                return View(userVM);
            }
        }

        //POST edit action
        [HttpPost]
        public IActionResult Edit(UserViewModel obj)
        {
            //check for valid model state
            if (ModelState.IsValid)
            {
                using (UserDBContext db = new UserDBContext())
                {
                    //create an instance of the object
                    User u = obj.NewUser;
                    //retrieve info from route data
                    u.UserID = Guid.Parse(RouteData.Values["id"].ToString());
                    //update record state
                    db.Entry(u).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //delete an entry
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            UserViewModel userVM = new UserViewModel();
            using (UserDBContext db = new UserDBContext())
            {
                //create an instance of the view model
                userVM.NewUser = new User();
                //retrieve info from route data
                userVM.NewUser.UserID =
                    Guid.Parse(RouteData.Values["id"].ToString());
                //update record status
                db.Entry(userVM.NewUser).State = EntityState.Deleted;
                db.SaveChanges();
                TempData["ResultMessage"] = "The User has been deleted.";
            }
            return RedirectToAction("Index");
        }

    }
}

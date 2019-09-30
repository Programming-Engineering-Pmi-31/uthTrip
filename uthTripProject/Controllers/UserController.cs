using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uthTripProject.Models;

namespace uthTripProject.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            User userModel = new User();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(User userModel)
        {
            using (DbModels dbModel=new DbModels())
            {
                if(dbModel.Users.Any(x=>x.Username==userModel.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exists.";
                    return View("AddOrEdit", userModel);
                }
                try
                {
                    userModel.User_ID = dbModel.Users.Max(x => x.User_ID) + 1;
                }
                catch (System.InvalidOperationException)
                {
                    userModel.User_ID = 0;
                }
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("AddOrEdit", new User());
        }
    }
}
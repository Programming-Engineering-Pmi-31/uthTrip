using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uthTripProject.Models;
using System.Data.Entity.Infrastructure;
using System.Reflection;

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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User userModel)
        {
            if (ModelState.IsValid)
            {
                        
                using (DbModels dbModel = new DbModels())
                {
                    var obj= dbModel.Users.Where(a => a.Username == userModel.Username && a.Password == userModel.Password).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["User_ID"] = obj.User_ID.ToString();
                        Session["Username"] = obj.Username.ToString();
                        Session["Password"] = obj.Password.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                    return RedirectToAction("UserDashBoard");

                }
            }
            return View(userModel);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["User_ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AddOrEdit");
            }
        }
    }
}
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uthTripProject.Models;
using System.Data.Entity.Infrastructure;
using System.Reflection;
using AutoMapper;
using uthTrip.BLL.Interfaces;
using uthTrip.BLL.DTO;
using uthTrip.BLL.Infrastructure;

namespace uthTripProject.Controllers
{
    public class UserController : Controller
    {
        IUserService userService;
        public UserController(IUserService serv)
        {
            userService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<UserDTO> userDtos = userService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDtos);
            return View(users);
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            UserViewModel userModel = new UserViewModel();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(UserViewModel userModel)
        {
            try
            {
                userModel.User_ID = userService.FindMaxId() + 1;
                //userModel.User_ID = 1;
                //userModel.Birthday = DateTime.Now;
                var userDto = new UserDTO(userModel.User_ID, userModel.First_Name, userModel.Last_Name, userModel.Email, userModel.Username, userModel.Password, userModel.Birthday, userModel.Photo_Url, userModel.Info);
                userService.CreateUser(userDto);  
                ViewBag.SuccessMessage = "Registration Successful.";

            }
            //catch (InvalidOperationException)
            //{
            //    userModel.User_ID = 1;
            //    userModel.Birthday = DateTime.Now;
            //    //userService.CreateUser(userModel);
            //}
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                ModelState.Clear();
                ViewBag.DuplicateMessage = "Username already exists.";
                return View("AddOrEdit", userModel);
            }
            ModelState.Clear();
            return View("AddOrEdit", new UserViewModel());        
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var obj = userService.GetByUsernamePassword(userModel.Username,userModel.Password);
                    if (obj != null)
                    {
                        Session["User_ID"] = obj.User_ID.ToString();
                        Session["Username"] = obj.Username.ToString();
                        Session["Password"] = obj.Password.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                //ViewBag.DuplicateMessage = "Incorrect username or password.";
                return RedirectToAction("UserDashBoard");
            }
            return View(userModel);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["User_ID"] != null)
            {
                return RedirectToAction("AddOrEdit");
            }
            else
            {
                return RedirectToAction("AddOrEdit");
            }
        }
    }
}
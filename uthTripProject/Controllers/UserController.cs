﻿using Microsoft.AspNet.Identity.Owin;
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
<<<<<<< Updated upstream
                userModel.User_ID = userService.FindMaxId() + 1;
                var userDto = new UserDTO(userModel.User_ID, userModel.First_Name, userModel.Last_Name, userModel.Email, userModel.Username, userModel.Password, userModel.Birthday, userModel.Photo_Url, userModel.Info);
                userService.CreateUser(userDto);  
                ViewBag.SuccessMessage = "Registration Successful.";

=======
               
                    userModel.User_ID = this.userService.FindMaxId() + 1;
                    var userDto = new UserDTO(userModel.User_ID, userModel.First_Name, userModel.Last_Name, userModel.Email, userModel.Username, userModel.Password, userModel.Birthday, userModel.Photo_Url, userModel.Info);
                    this.userService.CreateUser(userDto);
                    return this.RedirectToAction("StartPage", "Home");
                
>>>>>>> Stashed changes
            }
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
<<<<<<< HEAD
<<<<<<< HEAD
        //public ActionResult Account(int id)
        //{
        //    var userAccount = userService.Get(id);
=======
        public ActionResult Account(int id)
        {
            var userAccount = userService.Get(id);
>>>>>>> parent of aa645ae... added unit tests for userservice

            var viewModel = new UserViewModel
            {
                User_ID = userAccount.User_ID,
            First_Name = userAccount.First_Name,
                Last_Name = userAccount.Last_Name,
                Username = userAccount.Username,
                Email = userAccount.Email,
                Password = userAccount.Password,
                Birthday = userAccount.Birthday,
                Photo_Url = userAccount.Photo_Url,
                Info = userAccount.Info
            };

<<<<<<< HEAD
        //    return View(viewModel);
        //}
=======

>>>>>>> parent of 3e60396... added unit tests to userservice
=======
            return View(viewModel);
        }
>>>>>>> parent of aa645ae... added unit tests for userservice
        [HttpPost]
        public ActionResult Login(UserViewModel userModel)
        {


            //if (ModelState.IsValid)
            //{
            ModelState.Clear();
                var obj = userService.GetByUsernamePassword(userModel.Username,userModel.Password);
                    if (obj != null)
                    {
                        Session["User_ID"] = obj.User_ID.ToString();
                        Session["Username"] = obj.Username.ToString();
                        Session["Password"] = obj.Password.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
            return RedirectToAction("UserDashBoard");
            //}

            //return View(userModel);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["User_ID"] != null)
            {
                return View("UserHome");
            }
            else
            {
                ViewBag.DuplicateMessage = "Incorrect username or password.";
                return View("Login");
            }
        } 
    }
}
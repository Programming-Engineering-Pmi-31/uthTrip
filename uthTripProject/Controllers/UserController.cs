using Microsoft.Owin.Security.Facebook;

namespace UthTripProject.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using AutoMapper;
    using Microsoft.AspNet.Identity.Owin;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Infrastructure;
    using UthTrip.BLL.Interfaces;
    using uthTripProject.Controllers;
    using UthTripProject.Models;

    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService serv)
        {
            this.userService = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<UserDTO> userDtos = this.userService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDtos);
            if (users.Count > 0)
            {
                this.ViewBag.Message = string.Format("В базі даних {0} об'єкт", users.Count);
            }

            return this.View(users);
        }

        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            UserViewModel userModel = new UserViewModel();
            return this.View(userModel);
        }

        [HttpPost]
        public ActionResult Register(UserViewModel userModel)
        {
            try
            {
                userModel.User_ID = this.userService.FindMaxId() + 1;
                userModel.Password = Helper.Encrypt(userModel.Password);
                var userDto = new UserDTO(userModel.User_ID, userModel.First_Name, userModel.Last_Name, userModel.Email, userModel.Username, userModel.Password, userModel.Birthday, userModel.Photo_Url, userModel.Info);
                this.userService.CreateUser(userDto);
                this.Session["User_ID"] = userDto.User_ID.ToString();
                this.Session["Username"] = userDto.Username.ToString();
                this.Session["Password"] = userDto.Password.ToString();
                return this.RedirectToAction("StartPage", "Home");
            }
            catch (ArgumentNullException ex)
            {
                this.ViewBag.DuplicateMessage = "Таке і'мя користувача вже існує.";
                return this.View("Register");
            }
        }


        [HttpGet]
        public ActionResult Login()
        {
            return this.View();
        }

        public ActionResult Account(int id)
        {
            var userAccount = this.userService.Get(id);
            var viewModel = new UserViewModel
            {
                User_ID = userAccount.User_ID,
                First_Name = userAccount.First_Name,
                Last_Name = userAccount.Last_Name,
                Username = userAccount.Username,
                Email = userAccount.Email,
                Password = userAccount.Email,
                Birthday = userAccount.Birthday,
                Photo_Url = userAccount.Photo_Url,
                Info = userAccount.Info,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(UserViewModel userModel)
        {
            this.ModelState.Clear();
            var obj = this.userService.GetByUsernamePassword(userModel.Username, userModel.Password);
            if (obj != null && userModel.Username == "admin" && userModel.Password == "admin")
            {
                this.Session["isAdmin"] = "true";
                this.Session["User_ID"] = obj.User_ID.ToString();
                this.Session["Username"] = obj.Username.ToString();
                this.Session["Password"] = obj.Password.ToString();
                return this.RedirectToAction("StartPage", "Home");
            }
            else if (obj != null)
            {
                this.Session["User_ID"] = obj.User_ID.ToString();
                this.Session["Username"] = obj.Username.ToString();
                this.Session["Password"] = obj.Password.ToString();
                return this.RedirectToAction("StartPage", "Home");
            }
            else
            {
                this.ViewBag.DuplicateMessage = "Неправильне і'мя користувача або пароль.";
                return this.View("Login");
            }
        }

        public ActionResult LogOut()
        {
            this.Session["User_ID"] = null;
            this.Session["Username"] = null;
            this.Session["Password"] = null;
            return this.View("Login");
        }

        public ActionResult UserProfile(int? id)
        {
            IEnumerable<UserDTO> users = this.userService.GetAll();
            var person = (from i in users
                          where i.User_ID == id
                          select i).ToList().First();

            List<int> userTrips = this.userService.GetAllTrips().Where(e => e.Creator_ID == id).Select(e => e.Trip_ID).ToList();
            var reviews = this.userService.GetAllReviews().Where(e => userTrips.Contains(e.Trip_ID)).Select(e => e.Review1);

            this.ViewBag.Reviews = reviews.ToList();
            return this.View(person);
        }

        public ActionResult AllUsers()
        {
            IEnumerable<UserDTO> users = this.userService.GetAll();
            IEnumerable<BlockedUsersDTO> blockedUsers = this.userService.GetAllBlocked();
            List<UserBlockedModel> userBlockedModels = new List<UserBlockedModel>();
            if (blockedUsers != null)
            {
                foreach (var item in users)
                {
                    bool found = false;
                    foreach (var bl in blockedUsers)
                    {
                        if (item.User_ID == bl.User_ID)
                        {
                            userBlockedModels.Add(new UserBlockedModel(item.User_ID, item.First_Name, item.Last_Name, item.Email,
                                item.Username, item.Password, item.Birthday, item.Photo_Url, item.Info, true));
                            found = true;
                            break;
                        }
                    }

                    if (found == false)
                    {
                        userBlockedModels.Add(new UserBlockedModel(item.User_ID, item.First_Name, item.Last_Name, item.Email,
                                item.Username, item.Password, item.Birthday, item.Photo_Url, item.Info, false));
                    }
                }
            }
            else
            {
                foreach (var u in users)
                {
                    userBlockedModels.Add(new UserBlockedModel(u.User_ID, u.First_Name, u.Last_Name, u.Email,
                                u.Username, u.Password, u.Birthday, u.Photo_Url, u.Info, false));
                }
            }

            return this.View(userBlockedModels);
        }

        public ActionResult Block(int id)
        {
            int bl_id = this.userService.FindMaxIdBl()+1;
            BlockedUsersDTO blockedUsersDTO = new BlockedUsersDTO(bl_id, id);
            this.userService.CreateBlocked(blockedUsersDTO);
            return this.RedirectToAction("AllUsers");
        }

        public ActionResult Unblock(int id)
        {
            int id_ = this.userService.GetAllBlocked().Where(e => e.User_ID == id).Select(e => e.Blocked_ID).First();
            this.userService.DisposeBlocked(id_);
            return this.RedirectToAction("AllUsers");
        }
    }
}
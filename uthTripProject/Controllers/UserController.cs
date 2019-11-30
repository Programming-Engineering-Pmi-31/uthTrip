namespace UthTripProject.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Microsoft.AspNet.Identity.Owin;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Infrastructure;
    using UthTrip.BLL.Interfaces;
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
            ////var model = repo.GetComputerList();
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
                var userDto = new UserDTO(userModel.User_ID, userModel.First_Name, userModel.Last_Name, userModel.Email, userModel.Username, userModel.Password, userModel.Birthday, userModel.Photo_Url, userModel.Info);
                this.userService.CreateUser(userDto);
                this.Session["User_ID"] = userDto.User_ID.ToString();
                this.Session["Username"] = userDto.Username.ToString();
                this.Session["Password"] = userDto.Password.ToString();
                return this.RedirectToAction("StartPage", "Home");
            }
            catch (ArgumentNullException ex)
            {
                this.ViewBag.DuplicateMessage = "Username already exists.";
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
                Password = userAccount.Password,
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
            if (obj != null)
            {
                this.Session["User_ID"] = obj.User_ID.ToString();
                this.Session["Username"] = obj.Username.ToString();
                this.Session["Password"] = obj.Password.ToString();
                return this.RedirectToAction("StartPage", "Home");
            }
            else
            {
                this.ViewBag.DuplicateMessage = "Incorrect username or password.";
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
    }
}
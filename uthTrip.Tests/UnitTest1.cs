using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using NUnit.Framework;
using UthTrip.BLL.Services;
using UthTrip.BLL.Interfaces;
using UthTripProject.Models;
using UthTrip.DAL.Interfaces;
using UthTrip.DAL.EF;
using UthTrip.DAL.Repositories;
using UthTrip.BLL.DTO;
using UthTrip.DAL.Entities;
using UthTrip.BLL.Infrastructure;
using UthTripProject.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

using Moq;

namespace UthTrip.Tests
{
    //    [TestClass]
    //    public class UnitTest1
    //    {
    //        readonly string testConnectionString = "Initial Catalog=UthTripDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    //        UserService CreateUserService()
    //        {
    //            return new UserService(
    //                new EFUnitOfWork(
    //                    new UthTripContext(testConnectionString)
    //                )
    //            );
    //        }

    //        //[TearDown]
    //        //public void ClearDB()
    //        //{
    //        //    var context = new UthTripContext(testConnectionString);
    //        //    context.Users.RemoveRange(context.Users);
    //        //    context.SaveChanges();
    //        //}

    //        //[Test]
    //        //public void CreateTest()
    //        //{
    //        //    var userService = CreateUserService();

    //        //    DateTime somedate = new DateTime(2000, 07, 21);

    //        //    UserDTO usermodel = new UserDTO();
    //        //    usermodel.User_ID = 2;
    //        //    usermodel.First_Name = "Nadia";
    //        //    usermodel.Last_Name = "Padalka";
    //        //    usermodel.Email = "nadiapadalka@gmail.com";
    //        //    usermodel.Username = "nadiapadalka";
    //        //    usermodel.Password = "1111";
    //        //    usermodel.Birthday = somedate;
    //        //    usermodel.Photo_Url = "www";
    //        //    usermodel.Info = "super girl";
    //        //    userService.CreateUser(usermodel);

    //        //    var user = userService.GetAll().SingleOrDefault();
    //        //    Assert.AreEqual("Nadia", user.First_Name);
    //        //}
    //        [TestMethod]
    //        public void Sum_Products_Correctly()
    //        {
    //            // Arrange (добавляем имитированный объект)
    //            Mock<UserService> mock = new Mock<UserService>();
    //            mock.Setup(m => m.GetAll());

    //            UserController controller = new UserController(mock.Object);
    //            //string expected = "В базе данных 1 объект";

    //            // Act

    //            ViewResult result = controller.Index() as ViewResult;
    //            string actual = result.ViewBag.Message as string;

    //            // Assert
    //            Assert.IsNotNull(result.Model);
    //        }
    //        //[Test]
    //        //public void DeleteUser()
    //        //{
    //        //    var userService = CreateUserService();

    //        //    DateTime somedate = new DateTime(2000, 07, 21);

    //        //    UserDTO usermodel = new UserDTO();
    //        //    usermodel.User_ID = 2;
    //        //    usermodel.First_Name = "Nadia";
    //        //    usermodel.Last_Name = "Padalka";
    //        //    usermodel.Email = "nadiapadalka@gmail.com";
    //        //    usermodel.Username = "nadiapadalka";
    //        //    usermodel.Password = "1111";
    //        //    usermodel.Birthday = somedate;
    //        //    usermodel.Photo_Url = "www";
    //        //    usermodel.Info = "super girl";
    //        //    userService.CreateUser(usermodel);

    //        //    var user = userService.GetAll().SingleOrDefault();

    //        //    userService.Dispose(user.User_ID);
    //        //    Assert.AreEqual(0, userService.GetAll().Count());
    //        //}



    //        //[Test]
    //        //public void GetByIdTest()
    //        //{
    //        //    var userService = CreateUserService();

    //        //    DateTime somedate = new DateTime(2000, 07, 21);

    //        //    UserDTO usermodel = new UserDTO();
    //        //    usermodel.User_ID = 2;
    //        //    usermodel.First_Name = "Nadia";
    //        //    usermodel.Last_Name = "Padalka";
    //        //    usermodel.Email = "nadiapadalka@gmail.com";
    //        //    usermodel.Username = "nadiapadalka";
    //        //    usermodel.Password = "1111";
    //        //    usermodel.Birthday = somedate;
    //        //    usermodel.Photo_Url = "www";
    //        //    usermodel.Info = "super girl";
    //        //    userService.CreateUser(usermodel);
    //        //    var user = userService.GetAll().FirstOrDefault();
    //        //    Assert.NotNull(userService.GetById(user.User_ID));
    //        //}

    //        //[Test]
    //        //public void GetAll()
    //        //{
    //        //    var userService = CreateUserService();

    //        //    DateTime somedate = new DateTime(2000, 07, 21);

    //        //    UserDTO usermodel = new UserDTO();
    //        //    usermodel.User_ID = 2;
    //        //    usermodel.First_Name = "Nadia";
    //        //    usermodel.Last_Name = "Padalka";
    //        //    usermodel.Email = "nadiapadalka@gmail.com";
    //        //    usermodel.Username = "nadiapadalka";
    //        //    usermodel.Password = "1111";
    //        //    usermodel.Birthday = somedate;
    //        //    usermodel.Photo_Url = "www";
    //        //    usermodel.Info = "super girl";
    //        //    userService.CreateUser(usermodel);
    //        //    UserDTO user1 = new UserDTO(3, "Marichka", "Dymyd", "mariia@gmail.com", "mariicka", "1212", somedate, "www", "giirl");
    //        //    userService.CreateUser(user1);

    //        //    Assert.AreEqual(2, userService.GetAll().Count());
    //        //}
    //    }
}
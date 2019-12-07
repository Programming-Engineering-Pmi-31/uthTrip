using System;
<<<<<<< Updated upstream
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using uthTrip.BLL.Services;
using uthTrip.BLL.Interfaces;
using uthTripProject.Models;
using uthTrip.DAL.Interfaces;
using uthTrip.DAL.EF;
using uthTrip.DAL.Repositories;
using uthTrip.BLL.DTO;
using uthTrip.BLL.Infrastructure;


namespace uthTrip.Tests
{
    public class UnitTest1
    {
        readonly string testConnectionString = "Initial Catalog=UthTripDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        UserService CreateUserService()
        {
            return new UserService(
                new EFUnitOfWork(
                    new uthtripContext(testConnectionString)
                )
            );
        }

        [TearDown]
        public void ClearDB()
        {
            var context = new uthtripContext(testConnectionString);
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();
        }

        [Test]
        public void CreateTest()
        {
            var userService = CreateUserService();

            DateTime somedate = new DateTime(2000, 07, 21);

            UserDTO usermodel = new UserDTO();
            usermodel.User_ID = 2;
            usermodel.First_Name = "Nadia";
            usermodel.Last_Name = "Padalka";
            usermodel.Email = "nadiapadalka@gmail.com";
            usermodel.Username = "nadiapadalka";
            usermodel.Password = "1111";
            usermodel.Birthday = somedate;
            usermodel.Photo_Url = "www";
            usermodel.Info = "super girl";
            userService.CreateUser(usermodel);

            var user = userService.GetAll().SingleOrDefault();
            Assert.AreEqual("Nadia", user.First_Name);
        }

        [Test]
        public void DeleteUser()
        {
            var userService = CreateUserService();

            DateTime somedate = new DateTime(2000, 07, 21);

            UserDTO usermodel = new UserDTO();
            usermodel.User_ID = 2;
            usermodel.First_Name = "Nadia";
            usermodel.Last_Name = "Padalka";
            usermodel.Email = "nadiapadalka@gmail.com";
            usermodel.Username = "nadiapadalka";
            usermodel.Password = "1111";
            usermodel.Birthday = somedate;
            usermodel.Photo_Url = "www";
            usermodel.Info = "super girl";
            userService.CreateUser(usermodel);

            var user = userService.GetAll().SingleOrDefault();

            userService.Dispose(user.User_ID);
            Assert.AreEqual(0, userService.GetAll().Count());
        }



        [Test]
        public void GetByIdTest()
        {
            var userService = CreateUserService();

            DateTime somedate = new DateTime(2000, 07, 21);

            UserDTO usermodel = new UserDTO();
            usermodel.User_ID = 2;
            usermodel.First_Name = "Nadia";
            usermodel.Last_Name = "Padalka";
            usermodel.Email = "nadiapadalka@gmail.com";
            usermodel.Username = "nadiapadalka";
            usermodel.Password = "1111";
            usermodel.Birthday = somedate;
            usermodel.Photo_Url = "www";
            usermodel.Info = "super girl";
            userService.CreateUser(usermodel);
            var user = userService.GetAll().FirstOrDefault();
            Assert.NotNull(userService.GetById(user.User_ID));
        }

        [Test]
        public void GetAll()
        {
            var userService = CreateUserService();

            DateTime somedate = new DateTime(2000, 07, 21);

            UserDTO usermodel = new UserDTO();
            usermodel.User_ID = 2;
            usermodel.First_Name = "Nadia";
            usermodel.Last_Name = "Padalka";
            usermodel.Email = "nadiapadalka@gmail.com";
            usermodel.Username = "nadiapadalka";
            usermodel.Password = "1111";
            usermodel.Birthday = somedate;
            usermodel.Photo_Url = "www";
            usermodel.Info = "super girl";
            userService.CreateUser(usermodel);
            UserDTO user1 = new UserDTO(3, "Marichka", "Dymyd", "mariia@gmail.com", "mariicka", "1212", somedate, "www", "giirl");
            userService.CreateUser(user1);

            Assert.AreEqual(2, userService.GetAll().Count());
        }
=======
using Xunit;
using UthTrip.DAL.EF;
using UthTrip.DAL.Entities;
using System.Collections.Generic;
using UthTrip.DAL.Repositories;
using Moq;
using UthTrip.BLL.DTO;
using System.Data.Entity;
using System.Linq;
using Effort;
using UthTrip.BLL.Services;
using System.Data;
using System.Data.Common;
namespace UnitTestProject1
{

    public class UserServiceTest : IDisposable
    {
        DbConnection connection;
        UthTripContext databaseContext;

        UserService CreateUserService()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext = new UthTripContext(connection);
            return new UserService(new EFUnitOfWork(databaseContext));
        }

        public void Dispose()
        {
            databaseContext.Dispose();

        }
        [Fact]
        public void TestCreateUserMethod()
        {
            var userService = CreateUserService();


            userService.CreateUser(new UserDTO
            {
                User_ID = 132,
                First_Name = "Yaroslav",
                Last_Name = "Nolkuchak",
                Username = "user2",
                Email = "simonnolkuchak@com",
                Password = "1178",
                Birthday = DateTime.Now,
                Photo_Url = "www",
                Info = "another boy"
            });
            userService.CreateUser(new UserDTO
            {
                User_ID = 123,
                First_Name = "Simon",
                Last_Name = "Gilbert",
                Username = "simongilbert",
                Email = "simongilbert@com",
                Password = "1111",
                Birthday = DateTime.Now,
                Photo_Url = "www",
                Info = "some boy"
            });



            int res = userService.GetAll().Count();

            Assert.Equal(2, res);

        }

        [Fact]
        public void TestDeleteUserMethod()
        {
            var userService = CreateUserService();



            userService.CreateUser(new UserDTO
            {
                User_ID = 132,
                First_Name = "Yaroslav",
                Last_Name = "Nolkuchak",
                Username = "user2",
                Email = "simonnolkuchak@com",
                Password = "1178",
                Birthday = DateTime.Now,
                Photo_Url = "www",
                Info = "another boy"
            });
            userService.CreateUser(new UserDTO
            {
                User_ID = 123,
                First_Name = "Simon",
                Last_Name = "Gilbert",
                Username = "simongilbert",
                Email = "simongilbert@com",
                Password = "1111",
                Birthday = DateTime.Now,
                Photo_Url = "www",
                Info = "some boy"
            });


            var user = userService.GetAll().FirstOrDefault();
            userService.Dispose(user.User_ID);
            int res = userService.GetAll().Count();

            Assert.Equal(1, res);

        }
        [Fact]
        public void TestGetByID()
        {


            var userService = CreateUserService();
            userService.CreateUser(new UserDTO
            {
                User_ID = 132,
                First_Name = "Yaroslav",
                Last_Name = "Nolkuchak",
                Username = "user2",
                Email = "simonnolkuchak@com",
                Password = "1178",
                Birthday = DateTime.Now,
                Photo_Url = "www",
                Info = "another boy"
            });
            userService.CreateUser(new UserDTO
            {
                User_ID = 123,
                First_Name = "Simon",
                Last_Name = "Gilbert",
                Username = "simongilbert",
                Email = "simongilbert@com",
                Password = "1111",
                Birthday = DateTime.Now,
                Photo_Url = "www",
                Info = "some boy"
            });

            var user = userService.GetAll().FirstOrDefault();
            Assert.NotNull(userService.GetById(user.User_ID));



        }



        [Fact]
        public void TestFindMax_Id()
        {

            var userService = CreateUserService();
            userService.CreateUser(new UserDTO
            {
                User_ID = 132,
                First_Name = "Yaroslav",
                Last_Name = "Nolkuchak",
                Username = "user2",
                Email = "simonnolkuchak@com",
                Password = "1178",
                Birthday = DateTime.Now,
                Photo_Url = "www",
                Info = "another boy"
            });
            userService.CreateUser(new UserDTO
            {
                User_ID = 123,
                First_Name = "Simon",
                Last_Name = "Gilbert",
                Username = "simongilbert",
                Email = "simongilbert@com",
                Password = "1111",
                Birthday = DateTime.Now,
                Photo_Url = "www",
                Info = "some boy"
            });

            var user = userService.GetAll().FirstOrDefault();

            Assert.Equal(2, userService.FindMaxId());



        }






>>>>>>> Stashed changes
    }
}
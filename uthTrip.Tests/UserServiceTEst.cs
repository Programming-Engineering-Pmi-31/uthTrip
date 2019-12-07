using System;
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

    public class UserServiceTest:IDisposable
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
        { var userService = CreateUserService();



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
        
        




    }
}
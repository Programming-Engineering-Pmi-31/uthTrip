namespace UnitTestProject1
{
    using System;
    using System.Collections.Generic
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.InMemory;
    using Moq;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Services;
    using UthTrip.DAL.EF;
    using UthTrip.DAL.Entities;
    using UthTrip.DAL.Repositories;
[TestClass]
public class UserServiceTest
{
    private Mock<UserRepository> mockRepository;
    private UserService _service;
     Mock<EFUnitOfWork> _mockUnitWork;
     List<UserDTO> listUser;

    [TestInitialize]
    public void Initialize()
    {
        mockRepository = new Mock<UserRepository>();
        _mockUnitWork = new Mock<EFUnitOfWork>();
        _service = new UserService(_mockUnitWork.Object);
        listUser = new List<UserDTO>() {
           new UserDTO{

    using Xunit;

    public class UnitTest1 : IDisposable
    {
        public void Dispose()
        {
            var options = new DbContextOptionsBuilder<UthTripContext>()
                             .UseInMemoryDatabase(databaseName: "UserDatabase").Options;

            var context = new UthTripContext(options);
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();
        }

        [Fact]
        public void TestCreateUserMethod()
        {
            var options = new DbContextOptionsBuilder<UthTripContext>()
                             .UseInMemoryDatabase(databaseName: "UserDatabase").Options;
            var userService = this.CreateUserService();

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
                    Info = "another boy",
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
                    Info = "some boy",
                });
            // Use a clean instance of the context to run the test
            int res = userService.GetAll().Count();

            Assert.Equal(2, res);
        }

        [Fact]
        public void TestDeleteUserMethod()
        {
            var options = new DbContextOptionsBuilder<UthTripContext>()
                              .UseInMemoryDatabase(databaseName: "UsersDatabase").Options;
            var userService = this.CreateUserService();

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
                    Info = "another boy",
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
                    Info = "some boy",
                });
            userService.Dispose(123);
            int res = userService.GetAll().Count();

            Assert.Equal(1, res);
        }

        [Fact]
        public void TestGetByID()
        {
            var userService = this.CreateUserService();
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
                    Info = "another boy",
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
                    Info = "some boy",
                });

            var user = userService.GetAll().FirstOrDefault();
            Assert.NotNull(userService.GetById(user.User_ID));
            }

        [Fact]
        public void TestGetUserName_Password()
        {
            var userService = this.CreateUserService();
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
                Info = "another boy" },
           new UserDTO
                Info = "another boy",
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
            }  
          };
    }

    [TestMethod]
    public void Country_Get_All()
    {
        //Arrange
        //mockRepository.Setup(x => x.GetAll()).Returns(listUser);
       
        //Act
        List<UserDTO> results = _service.GetAll() as List<UserDTO>;

        //Assert
       
        Assert.AreEqual(2, results.Count);
    }


    [TestMethod]
    public void Can_Add_Country()
    {
        //Arrange
        int Id = 123;
            UserDTO user = new UserDTO

                Info = "some boy",
            });

            var user = userService.GetAll().FirstOrDefault();
            Assert.NotNull(userService.GetByUsernamePassword("simongilbert", "1111"));
        }

        [Fact]
        public void TestFindMax_Id()
        {
            var userService = this.CreateUserService();
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
                Info = "another boy",
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
            };
       


        //Act
        _service.CreateUser(user);

        //Assert
        Assert.AreEqual(Id, user.User_ID);
        _mockUnitWork.Verify(m => m.Save(), Times.Once);
    }


}

                Info = "some boy",
            });

            var user = userService.GetAll().FirstOrDefault();
            Assert.Equal(132, userService.FindMaxId());
        }

        private UserService CreateUserService()
        {
            var options = new DbContextOptionsBuilder<UthTripContext>()
                .UseInMemoryDatabase(databaseName: "UserDatabase").Options;
            return new UserService(
                new EFUnitOfWork(
                    new UthTripContext(options)));
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System;
using Moq;
using uthTripProject.Controllers;
using uthTripProject.Models;
using uthTrip.BLL.Services;
using uthTrip.BLL.Interfaces;
using uthTrip.BLL.DTO;
using System.Web.Mvc;
using Xunit;

namespace uthTripProject.Tests
{
    public class HomeControllerTests
    {
        DateTime somedate = new DateTime(2000, 07, 21);

        [Fact]
        public void Index_View_Result()
        {
            // Setup
            var expectedUserAccountCount = 2;

            var mockUserAccountService = new Mock<IUserService>();

            mockUserAccountService.Setup(x => x.GetAll())
                .Returns(GetTestUserAccounts());

            // Inject
            var homeController = new UserController(mockUserAccountService.Object);

            // Act
            var result = homeController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<UserViewModel>>(
                viewResult.ViewData.Model);

            Assert.Equal(expectedUserAccountCount, model.Count());
        }

        [Fact]
        public void Account_View_Result_One()
        {
            // Setup
            var expectedUserAccountId = 123;

            var mockUserAccountService = new Mock<IUserService>();

            mockUserAccountService.Setup(x => x.Get(expectedUserAccountId))
                .Returns(GetTestUserAccountOne());

            // Inject
            var homeController = new UserController(mockUserAccountService.Object);

            // Act
            var result = homeController.Account(expectedUserAccountId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            var viewModel = Assert.IsAssignableFrom<UserViewModel>(
                viewResult.ViewData.Model);

            Assert.Equal(expectedUserAccountId, viewModel.User_ID);
        }

        [Fact]
        public void Account_View_Result_Two()
        {
            // Setup
            var expectedUserAccountId = 456;

            var mockUserAccountService = new Mock<IUserService>();

            mockUserAccountService.Setup(x => x.Get(expectedUserAccountId))
                .Returns(GetTestUserAccountTwo());
            
            // Inject
            var homeController = new UserController(mockUserAccountService.Object);

            // Act
            var result = homeController.Account(expectedUserAccountId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            var viewModel = Assert.IsAssignableFrom<UserViewModel>(
                viewResult.ViewData.Model);

            Assert.Equal(expectedUserAccountId, viewModel.User_ID);
        }

        //[Fact]
        //public void Get_First_Name_Result()
        //{
        //    // Setup
        //    var userAccountId = 123;
        //    var userAccountFirstName = "Simon";

        //    var mockUserAccountService = new Mock<IUserService>();

        //    mockUserAccountService.Setup(x => x.GetFirstName(userAccountId))
        //        .Returns(userAccountFirstName);

        //    // Inject
        //    var homeController = new UserController(mockUserAccountService.Object);

        //    // Act
        //    var result = homeController.ActionInvoker

        //    // Assert
        //    Assert.Equal(userAccountFirstName, result);
        //}
        
        private List<UserDTO> GetTestUserAccounts()
        {
            return new List<UserDTO>()
            {
                GetTestUserAccountOne(),
                GetTestUserAccountTwo(),
            };
        }

        private UserDTO GetTestUserAccountOne()
        {

            return new UserDTO
            {
                User_ID = 123,
                First_Name = "Simon",
                Last_Name = "Gilbert",
                Username = "simongilbert",
                Email = "simongilbert@com",
                Password = "1111",
                Birthday = somedate,
                Photo_Url = "www",
                Info = "some boy"
            };
        }

        private UserDTO GetTestUserAccountTwo()
        {
            return new UserDTO
            {
                User_ID = 456,
                First_Name = "Alexander",
                Last_Name = "Hill",
                Username = "alexhill",
                Email = "alexhill@com",
                Password = "1111",
                Birthday = somedate,
                Photo_Url = "www",
                Info = "anpther boy"
            };
        }
    }
}

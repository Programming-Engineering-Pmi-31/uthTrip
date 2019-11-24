namespace uthTripProject.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Moq;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Interfaces;
    using UthTrip.BLL.Services;
    using uthTripProject.Controllers;
    using uthTripProject.Models;
    using Xunit;
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
                .Returns(this.GetTestUserAccounts());

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
                .Returns(this.GetTestUserAccountOne());

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
                .Returns(this.GetTestUserAccountTwo());
            
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

        /*[Fact]
        public void Get_First_Name_Result()
        {
            // Setup
            var userAccountId = 123;
            var userAccountFirstName = "Simon";

            var mockUserAccountService = new Mock<IUserService>();

            mockUserAccountService.Setup(x => x.GetFirstName(userAccountId))
                .Returns(userAccountFirstName);

            // Inject
            var homeController = new UserController(mockUserAccountService.Object);

            // Act
            var result = homeController.ActionInvoker

            // Assert
            Assert.Equal(userAccountFirstName, result);
        }
        */

        private List<UserDTO> GetTestUserAccounts()
        {
            return new List<UserDTO>()
            {
                this.GetTestUserAccountOne(),
                this.GetTestUserAccountTwo(),
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
                Birthday = this.somedate,
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
                Birthday = this.somedate,
                Photo_Url = "www",
                Info = "anpther boy"
            };
        }
    }
}

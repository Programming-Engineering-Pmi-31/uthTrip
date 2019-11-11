using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
//using Microsoft.AspNetCore.Mvc;
using uthTrip.BLL.Services;
using uthTrip.DAL.Interfaces;
using uthTrip.BLL.Interfaces;
using Moq;
using Xunit;
using uthTripProject.Controllers;
using System.Web;
namespace Tests
{
    
    public class UnitTest1
    {
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

            var model = Assert.IsAssignableFrom<IEnumerable<UserAccountViewModel>>(
                viewResult.ViewData.Model);

            Assert.Equal(expectedUserAccountCount, model.Count());
        }

    }
}

//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Web.Mvc;
//using Moq;
//namespace UnitTests
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void Sum_Products_Correctly()
//        {
//            // Arrange (добавляем имитированный объект)
//            Mock<UserService> mock = new Mock<UserService>();
//            mock.Setup(m => m.GetAll());

//            UserController controller = new UserController(mock.Object);
//            string expected = "В базе данных 1 объект";

//            // Act
//            controller.Index();
//            ViewResult result = controller.Index() as ViewResult;
//            string actual = result.ViewBag.Message as string;

//            // Assert
//            Assert.AreEqual(expected, actual);
//        }
//    }
//}

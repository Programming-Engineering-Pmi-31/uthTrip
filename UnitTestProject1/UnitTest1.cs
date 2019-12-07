namespace UnitTestProject1
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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
}
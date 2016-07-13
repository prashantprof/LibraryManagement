using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagement.Service.Concrete;
using LibraryManagement.Service.Models;

namespace LibraryManagement.Tests.Services
{
    [TestClass]
    public class UserTest
    {
        UserService service = null;
        public UserTest()
        {
            service = new UserService();
        }
        [TestMethod]
        public void GetUsersByRoleID(int roleid)
        {
            //Arrange
            var user = service.GetUsersByRoleID(1);
            //Act
            //Assert
            Assert.IsNotNull(user);
        }
        /*[TestMethod]
        public void SaveUser_WithNewUserRole()
        {
            //Arrange
            UserModel newUser = new UserModel()
            {
                FirstName = "Siddhant",
                LastName = "Soni",
                EmaildID = "siddhantsoni2695@gmail.com",
                Password = "manhattan",
                MobileNumber = '9826469628',
                AddressOne = "EWS-344 Kotra Sultanabad",
                AddressTwo = "Bhopal",
                IsActive = true,
                Deposit = 500
            };
            newUser.UserRoleDetails = new UserRoleModel()
            {
                Role = "User"
            };
            //Act
            var listOfUsers = service.SaveUser(newUser);

            //Assert
            Assert.AreNotEqual(listOfUsers.Count, 0);
        }*/
    }
}

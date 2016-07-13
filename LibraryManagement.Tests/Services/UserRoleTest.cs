using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagement.Service.Concrete;
using LibraryManagement.Service.Models;

namespace LibraryManagement.Tests.Services
{
    [TestClass]
    public class UserRoleTest
    {
        UserRoleService service = null;
        public UserRoleTest()
        {
            service = new UserRoleService();
        }
        [TestMethod]

        public void GetUserRoleByID()
        {
            //Arrange
            UserRoleModel userrole = service.GetUserRoleById(1);
            //Act
            //Assert
            Assert.IsNotNull(userrole);

        }
    }
}

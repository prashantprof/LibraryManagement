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
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagement.Service.Concrete;

namespace LibraryManagement.Tests.Services
{
    [TestClass]
    public class BookIssueTest
    {
        BookIssueService service = null;

        public BookIssueTest()
        {
            service = new BookIssueService();
        }

        [TestMethod]
        public void GetBookIssueByUserId(int userID)
        {
            //Arrange
            var bookissue = service.GetBookIssueByUserId(100);
            //Act
            //Assert
            Assert.IsNotNull(bookissue);
        }
    }
}

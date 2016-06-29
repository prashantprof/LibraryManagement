using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagement.Repository.Concrete;
using LibraryManagement.Repository.DatabaseEntities;

namespace LibraryManagement.Tests.Repositories
{
    [TestClass]
    public class BookIssueTest
    {
        BookIssueRepository repository = null;
     
        public BookIssueTest()
        {
            repository = new BookIssueRepository();
        }

        [TestMethod]
        public void GetBookIssueById()
        {
            BookIssue bookissue = repository.GetBookIsssueById(1);

            Assert.IsNotNull(bookissue);
        }
    }
}

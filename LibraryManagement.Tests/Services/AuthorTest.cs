using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagement.Service.Concrete;
using LibraryManagement.Service.Models;

namespace LibraryManagement.Tests.Services
{
    /// <summary>
    /// Summary description for AuthorTest
    /// </summary>
    [TestClass]
    public class AuthorTest
    {
        AuthorService service = null;
        public AuthorTest()
        {
            service = new AuthorService();
        }

        [TestMethod]
        public void GetAuthorByID()
        {
            AuthorModel author = service.GetAuthorByID(2);

            Assert.IsNotNull(author);
        }

        [TestMethod]
        public void GetAuthors()
        {
            var author = service.GetAuthors();

            Assert.IsNotNull(author);
            Assert.AreNotEqual(author.Count, 0);
        }

        [TestMethod]
        public void AddNewAuthor()
        {
            AuthorModel newAuthor = new AuthorModel()
            {
                AuthorID = 12,
                FirstName = "Shubham",
                LastName = "Jadiya",
                AboutAuthor = "Ek aur Aatankwadi hai."
            };
            var id = service.SaveAuthor(newAuthor);

            Assert.IsNotNull(id);
            Assert.AreNotEqual(id, 0);
        }
    }
}

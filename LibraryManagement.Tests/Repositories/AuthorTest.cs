using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagement.Repository.Concrete;
using LibraryManagement.Repository.DatabaseEntities;

namespace LibraryManagement.Tests.Repositories
{
    /// <summary>
    /// Summary description for AuthorTest
    /// </summary>
    [TestClass]
    public class AuthorTest
    {
        AuthorRepository repository = null;
        public AuthorTest()
        {
            repository = new AuthorRepository();
        }

        [TestMethod]
        public void GetAuthorByID()
        {
            Author author = repository.GetAuthorByID(2);

            Assert.IsNotNull(author);
        }

        [TestMethod]
        public void GetAuthors()
        {
            List<Author> authors = repository.GetAuthors();

            Assert.IsNotNull(authors);
        }

        [TestMethod]
        public void AddAuthor()
        {
            Author newAuthor = new Author()
            {
                FirstName = "Siddhant",
                LastName = "Soni",
                AboutAuthor = "My name is Siddhant Soni and I am inserting data from a test."
            };
            int id = repository.AddAuthor(newAuthor);

            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void UpdateAuthor_Negetive()
        {
            Author newAuthor = new Author()
            {
                AuthorID = 7,
                FirstName = "Vinay",
                LastName = "Soni",
                AboutAuthor = "My name is Siddhant Soni and I am updating my name from a test."
            };
            bool result = repository.UpdateAuthor(newAuthor);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void UpdateAuthor()
        {
            Author newAuthor = new Author()
            {
                AuthorID = 6,
                FirstName = "Vinay",
                LastName = "Soni",
                AboutAuthor = "My name is Siddhant Soni and I am updating my name from a test."
            };
            bool result = repository.UpdateAuthor(newAuthor);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void DeleteAuthor()
        {
            bool result = repository.DeleteAuthor(5);

            Assert.AreEqual(true, result);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagement.Service.Concrete;
using LibraryManagement.Service.Models;

namespace LibraryManagement.Tests.Services
{
    [TestClass]
    public class BookTest
    {
        BookService bookService = null;

        public BookTest()
        {
            bookService = new BookService();
        }

        [TestMethod]
        public void GetAllBooks()
        {
            //Arrange

            //Act
            var result = bookService.GetAllBooks();
            //Assert
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void SaveBook_WithNewAuthorAndCategory()
        {
            //Arrange
            BookModel newBook = new BookModel()
            {
                BookName = "Vardaan",
                ShortDescription = "",
                LongDescription = @"Vardan is about Pratap Cahndra and Brij Rani, two childhood neighbours who like each other." +
                " Brij gets married to another man and becomes a famous poet after being widowed. Her friend Madhvi starts liking Pratap" +
                " after hearing about him from Brij. Pratap becomes a sadhu, and Madhvi becomes his devotee. An unhappy housewife first becomes a courtesan," +
                " and then manages an orphanage for the young daughters of the courtesans.",
                AutherID = 0,
                CategoryID = 0,
                Price = 500,
                ImagePath = "TestImg"
            };
            newBook.AuthorDetails = new AuthorModel()
            {
                FirstName = "Munshi",
                LastName = "Premchand",
                AboutAuthor = "Premchand was born on 31 July 1880 in Lamhi, a village located near Varanasi (Banaras). His ancestors came from a large Kayastha family," +
                " which owned six bighas of land.[3] His grandfather Guru Sahai Rai was a patwari (village accountant), and his father Ajaib Rai was a post office clerk." +
                " His mother was Anandi Devi of Karauni village, who could have been the inspiration for the character Anandi in his Bade Ghar Ki Beti." +
                " Premchand was the fourth child of Ajaib Lal and Anandi; the first two were girls who died as infants, and the third one was a girl named Suggi." +
                " His parents named him Dhanpat Rai ('the master of wealth'), while his uncle, Mahabir, a rich landowner, nicknamed him 'Nawab' ('Prince'). " +
                "Nawab Rai was the first pen name chosen by Premchand",
            };
            newBook.CategoryDetails = new CategoryModel()
            {
                CategoryName = "Jalwa-e-Isar"
            };


            //Act
            var listOfBooks = bookService.SaveNewBook(newBook);

            //Assert
            Assert.AreNotEqual(listOfBooks.Count, 0);

        }
    }
}

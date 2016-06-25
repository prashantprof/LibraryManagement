using LibraryManagement.Repository.Concrete;
using LibraryManagement.Repository.DatabaseEntities;
using LibraryManagement.Service.Abstract;
using LibraryManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Concrete
{
    public class BookService : IBookService
    {
        BookRepository bookRepository = null;
        AuthorService authorService = null;
        CategoryService categoryService = null;

        public BookService()
        {
            bookRepository = new BookRepository();
            authorService = new AuthorService();
            categoryService = new CategoryService();
        }

        public List<BookModel> GetAllBooks()
        {
            try
            {
                List<BookModel> modelList = new List<BookModel>();
                List<Book> books = bookRepository.GetBooks();
                if (books != null && books.Any())
                {
                    BookModel bookModel = null;
                    foreach (var book in books)
                    {
                        bookModel = new BookModel()
                        {
                            AutherID = book.AutherID,
                            BookID = book.BookID,
                            BookName = book.BookName,
                            CategoryID = book.CategoryID,
                            ImagePath = book.ImagePath,
                            LongDescription = book.LongDescription,
                            Price = book.Price,
                            ShortDescription = book.ShortDescription
                        };

                        bookModel.AuthorDetails = new AuthorModel()
                        {
                            AuthorID = book.Author.AuthorID,
                            FirstName = book.Author.FirstName,
                            LastName = book.Author.LastName,
                            AboutAuthor = book.Author.AboutAuthor
                        };

                        bookModel.CategoryDetails = new CategoryModel()
                        {
                            CategoryID = book.Category.CategoryID,
                            CategoryName = book.Category.CategoryName
                        };
                        modelList.Add(bookModel);
                    }
                }

                return modelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<BookModel> SaveNewBook(BookModel newBook)
        {
            if (newBook != null)
            {
                if (newBook.BookID > 0) //For Update
                {
                    Book extBook = bookRepository.GetBookById(newBook.BookID);
                    if (extBook != null)
                    {
                        extBook.BookName = newBook.BookName;
                        extBook.LongDescription = newBook.LongDescription;
                        extBook.ShortDescription = newBook.LongDescription.Substring(0,100);
                        //Author has been changed
                        if (extBook.AutherID != newBook.AutherID)
                            extBook.AutherID = newBook.AutherID;
                        if (extBook.CategoryID != newBook.CategoryID)
                            extBook.CategoryID = newBook.CategoryID;
                        extBook.Price = newBook.Price;
                        extBook.ImagePath = newBook.ImagePath;
                        bookRepository.UpdateBook(extBook);
                    }
                }
                else //For Save
                {
                    if (newBook.AuthorDetails != null && newBook.AutherID.Equals(0))
                    {
                        newBook.AuthorDetails.AuthorID = authorService.SaveAuthor(newBook.AuthorDetails);
                        newBook.AutherID = newBook.AuthorDetails.AuthorID;
                    }
                    if (newBook.CategoryID.Equals(0))
                    {
                        newBook.CategoryDetails.CategoryID = categoryService.SaveCategory(newBook.CategoryDetails);
                        newBook.CategoryID = newBook.CategoryDetails.CategoryID;
                    }

                    Book book = new Book()
                    {
                        BookName = newBook.BookName,
                        LongDescription = newBook.LongDescription,
                        ShortDescription = newBook.LongDescription.Take(100).ToString(),
                        AutherID = newBook.AutherID,
                        CategoryID = newBook.CategoryID,
                        Price = newBook.Price,
                        ImagePath = newBook.ImagePath
                    };
                    bookRepository.AddBook(book);
                }
            }
            return GetAllBooks();
        }


    }
}

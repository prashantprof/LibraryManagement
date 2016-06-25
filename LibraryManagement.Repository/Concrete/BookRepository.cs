using LibraryManagement.Repository.Abstract;
using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Concrete
{
    public class BookRepository : IBookRepository
    {
        LibraryManagementEntities db = null;

        public BookRepository()
        {
            db = new LibraryManagementEntities();
        }
        public Book GetBookById(int id)
        {
            return db.Books.Where(x => x.BookID.Equals(id)).FirstOrDefault();
        }

        public List<Book> GetBooks()
        {
            return db.Books.ToList();
        }

        public int AddBook(Book newBook)
        {
            db.Books.Add(newBook);
            db.SaveChanges();
            return newBook.BookID;
        }

        public bool UpdateBook(DatabaseEntities.Book book)
        {
            var existingBook = db.Books.Where(x => x.BookID.Equals(book.BookID)).FirstOrDefault();
            if (existingBook != null)
            {
                existingBook.BookName = book.BookName;
                existingBook.ShortDescription = book.ShortDescription;
                existingBook.LongDescription = book.LongDescription;
                existingBook.AutherID = book.AutherID;
                existingBook.CategoryID = book.CategoryID;
                existingBook.Price = book.Price;
                existingBook.ImagePath = book.ImagePath;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool DeleteBook(int id)
        {
            var existingBook = db.Books.Where(x => x.BookID.Equals(id)).FirstOrDefault();
            if (existingBook != null)
            {
                db.Books.Remove(existingBook);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}

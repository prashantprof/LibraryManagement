using LibraryManagement.Repository.DatabaseEntities;
using LibraryManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Abstract
{
    public interface IBookService
    {
        BookModel GetBookById(int id);
        List<BookModel> GetAllBooks();
        List<BookModel> SaveNewBook(BookModel newBook);
        bool DeleteBook(int id);
        List<BookModel> GetBooksByCategoryId(int categoryId);
        List<BookModel> GetBooksByPrice(decimal price);
        List<BookModel> GetBooksByAuthorID(int authorID);
    }
}

using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Abstract
{
    interface IBookRepository
    {
        Book GetBookById(int id);
        List<Book> GetBooks();
        int AddBook(Book newBook);
        bool UpdateBook(Book book);
        bool DeleteBook(int id);
        List<Book> GetBooksByCategoryId(int categoryID);
        List<Book> GetBooksByPrice(decimal price);
    }
}

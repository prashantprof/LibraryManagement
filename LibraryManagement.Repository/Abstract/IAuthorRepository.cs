using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Abstract
{
    public interface IAuthorRepository
    {
        Author GetAuthorByID(int id);

        List<Author> GetAuthors();

        int AddAuthor(Author newAuthor);

        bool UpdateAuthor(Author author);

        bool DeleteAuthor(int id);
    } 
}

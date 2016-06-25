using LibraryManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Abstract
{
    public interface IAuthorService
    {
        AuthorModel GetAuthorByID(int id);

        List<AuthorModel> GetAuthors();

        int SaveAuthor(AuthorModel newAuthor);

        bool DeleteAuthor(int id);
    }
}

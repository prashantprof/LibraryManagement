using LibraryManagement.Repository.DatabaseEntities;
using LibraryManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Abstract
{
    public interface IBookIssueService
    {
        BookIssueModel GetBookIssueById(int id);

        List<BookIssueModel> BookIssues();

        int SaveBookIssue(BookIssueModel newBookIssue);

        bool DeleteBookIssue(int id);

        List<BookIssueModel> GetBookIssueByUserId(int userID);

        List<BookIssueModel> GetunreturnedBooks();
    }
}

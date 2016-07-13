using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Abstract
{
    public interface IBookIssueRepository
    {
        BookIssue GetBookIsssueById(int id);

        List<BookIssue> GetBookIssues();

        int AddBookIssue(BookIssue newBookIssue);

        bool UpdateBookIssue(BookIssue bookissue);

        bool DeleteBookIssue(int userID);
        List<BookIssue> GetBookIssueByUserId(int userID);
        
    }
}

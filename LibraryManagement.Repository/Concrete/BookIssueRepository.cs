using LibraryManagement.Repository.Abstract;
using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Concrete
{
    public class BookIssueRepository : IBookIssueRepository
    {
        LibraryManagementEntities db = null;

        public BookIssueRepository()
        {
            db = new LibraryManagementEntities();
        }

        public BookIssue GetBookIsssueById(int id)
        {
            return db.BookIssues.Where(x => x.BookIssueID.Equals(id)).FirstOrDefault();
        }


        public List<BookIssue> GetBookIssues()
        {
            return db.BookIssues.ToList();
        }

        public int AddBookIssue(BookIssue newBookIssue)
        {
            db.BookIssues.Add(newBookIssue);
            db.SaveChanges();
            return newBookIssue.BookIssueID;
        }

        public bool UpdateBookIssue(BookIssue bookissue)
        {
            var existingBookIssue = db.BookIssues.Where(x => x.BookIssueID.Equals(bookissue.BookIssueID)).FirstOrDefault();
            if (existingBookIssue != null)
            {
                existingBookIssue.BookID = bookissue.BookID;
                existingBookIssue.UserID = bookissue.UserID;
                existingBookIssue.IssueDate = bookissue.IssueDate;
                existingBookIssue.ReturnDate = bookissue.ReturnDate;
                existingBookIssue.FineAmount = bookissue.FineAmount;
                existingBookIssue.IssuerID = bookissue.IssuerID;

                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool DeleteBookIssue(int id)
        {
            var existingBookIssue = db.BookIssues.Where(x => x.BookIssueID.Equals(id)).FirstOrDefault();
            if (existingBookIssue != null)
            {
                db.BookIssues.Remove(existingBookIssue);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<BookIssue> GetBookIssueByUserId(int userID)
        {
            return db.BookIssues.Where(x => x.UserID == userID).ToList();
        }
    }
}

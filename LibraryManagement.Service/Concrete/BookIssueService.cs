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
    public class BookIssueService :IBookIssueService
    {
        BookIssueRepository bookissueRepository;

        public BookIssueService()
        {
            bookissueRepository = new BookIssueRepository();
        }

        public BookIssueModel GetBookIssueById(int id)
        {
            try
            {
                BookIssueModel model = null;
                BookIssue bookissue = bookissueRepository.GetBookIsssueById(id);
                if (bookissue != null)
                {
                    model = new BookIssueModel()
                    {
                        BookIssueID = model.BookIssueID,
                        BookID = model.BookID,
                        UserID = model.UserID,
                        IssueDate = model.IssueDate,
                        ReturnDate = model.ReturnDate,
                        FineAmount = model.FineAmount,
                        IssuerID = model.IssuerID
                    };
                }
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<BookIssueModel> GetBookIssues()
        {
            
            try
            {
                List<BookIssueModel> modelList = null;
                List<BookIssue> bookissues = bookissueRepository.GetBookIssues();
                if (bookissues != null && bookissues.Any())
                {
                    modelList = bookissues.Select(bookissue => new BookIssueModel()
                    {
                        BookIssueID = bookissue.BookIssueID,
                        BookID = bookissue.BookID,
                        UserID = bookissue.UserID,
                        IssueDate = bookissue.IssueDate,
                        ReturnDate = bookissue.ReturnDate,
                        FineAmount = bookissue.FineAmount,
                        IssuerID = bookissue.IssuerID
                    }).ToList();                   
                }
                return modelList;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public int SaveBookIssue(BookIssue newBookIssue)
        {
            try
            {
                if (newBookIssue != null)
                {
                    if (newBookIssue.BookIssueID>0)
                    {
                        var bookissue = bookissueRepository.GetBookIsssueById(newBookIssue.BookIssueID);
                        if (bookissue != null)
                        {
                            bookissue.BookIssueID = newBookIssue.BookIssueID;
                            bookissue.BookID = newBookIssue.BookID;
                            bookissue.UserID = newBookIssue.UserID;
                            bookissue.IssueDate = newBookIssue.IssueDate;
                            bookissue.ReturnDate = newBookIssue.ReturnDate;
                            bookissue.FineAmount = newBookIssue.FineAmount;
                            bookissue.IssuerID = newBookIssue.IssuerID;
                            bookissueRepository.UpdateBookIssue(bookissue);
                            return bookissue.BookIssueID;
                        }
                    }
                }
                else
                {
                    var bookissue = new BookIssue()
                    {
                        BookIssueID = newBookIssue.BookIssueID,
                        BookID = newBookIssue.BookID,
                        UserID = newBookIssue.UserID,
                        IssueDate = newBookIssue.IssueDate,
                        ReturnDate = newBookIssue.ReturnDate,
                        FineAmount = newBookIssue.FineAmount,
                        IssuerID = newBookIssue.IssuerID
                    };
                    return bookissueRepository.AddBookIssue(bookissue);
                }
                return 0;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool DeleteBookIssue(int id)
        {
            if (id > 0)
                return bookissueRepository.DeleteBookIssue(id);
            return false;
        }


        public List<BookIssue> BookIssues()
        {
            throw new NotImplementedException();
        }
    }

}

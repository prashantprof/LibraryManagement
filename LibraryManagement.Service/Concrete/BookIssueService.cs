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
    public class BookIssueService : IBookIssueService
    {
        BookIssueRepository bookissueRepository;
        BookService bookService;
        UserService userService;

        public BookIssueService()
        {
            bookissueRepository = new BookIssueRepository();
            bookService = new BookService();
            userService = new UserService();
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

        public int SaveBookIssue(BookIssueModel newBookIssue)
        {
            try
            {
                if (newBookIssue != null)
                {
                    if (newBookIssue.BookIssueID > 0)
                    {
                        var bookIssue = bookissueRepository.GetBookIsssueById(newBookIssue.BookIssueID);
                        if (bookIssue != null)
                        {
                            bookIssue.BookIssueID = newBookIssue.BookIssueID;
                            bookIssue.BookID = newBookIssue.BookID;
                            bookIssue.UserID = newBookIssue.UserID;
                            bookIssue.IssueDate = newBookIssue.IssueDate;
                            bookIssue.ReturnDate = newBookIssue.ReturnDate;
                            bookIssue.FineAmount = newBookIssue.FineAmount;
                            bookIssue.IssuerID = newBookIssue.IssuerID;
                            bookissueRepository.UpdateBookIssue(bookIssue);
                            return bookIssue.BookIssueID;
                        }
                    }
                }
                else
                {
                    var bookIssue = new BookIssue()
                    {
                        BookIssueID = newBookIssue.BookIssueID,
                        BookID = newBookIssue.BookID,
                        UserID = newBookIssue.UserID,
                        IssueDate = newBookIssue.IssueDate,
                        ReturnDate = newBookIssue.ReturnDate,
                        FineAmount = newBookIssue.FineAmount,
                        IssuerID = newBookIssue.IssuerID
                    };
                    return bookissueRepository.AddBookIssue(bookIssue);
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


        public List<BookIssueModel> GetBookIssueByUserId(int userID)
        {
            try
            {
                List<BookIssueModel> modelList = null;
                List<BookIssue> bookIssues = bookissueRepository.GetBookIssueByUserId(userID);
                if (bookIssues != null && bookIssues.Any())
                {
                    BookIssueModel model = null;
                    foreach (var bookIssue in bookIssues)
                    {
                        model = new BookIssueModel()
                        {
                            BookIssueID = bookIssue.BookIssueID,
                            BookID = bookIssue.BookID,
                            UserID = bookIssue.UserID,
                            IssueDate = bookIssue.IssueDate,
                            ReturnDate = bookIssue.ReturnDate,
                            FineAmount = bookIssue.FineAmount,
                            IssuerID = bookIssue.IssuerID
                        };
                        model.BookDetails = bookService.GetBookById(model.BookID);
                        model.UserDetails = userService.GetUserById(model.UserID);
                        model.IssuerDetails = userService.GetUserById(model.IssuerID);
                        modelList.Add(model);
                    }
                }
                return modelList;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<BookIssueModel> BookIssues()
        {
            try
            {
                List<BookIssueModel> modelList = new List<BookIssueModel>();
                List<BookIssue> bookIssues = bookissueRepository.GetBookIssues();
                if (bookIssues != null && bookIssues.Any())
                {
                    BookIssueModel model = null;
                    foreach (var bookIssue in bookIssues)
                    {
                        model = new BookIssueModel()
                        {
                            BookIssueID = bookIssue.BookIssueID,
                            BookID = bookIssue.BookID,
                            UserID = bookIssue.UserID,
                            IssueDate = bookIssue.IssueDate,
                            ReturnDate = bookIssue.ReturnDate,
                            FineAmount = bookIssue.FineAmount,
                            IssuerID = bookIssue.IssuerID
                        };
                        model.BookDetails = bookService.GetBookById(model.BookID);
                        model.UserDetails = userService.GetUserById(model.UserID);
                        model.IssuerDetails = userService.GetUserById(model.IssuerID);
                        modelList.Add(model);
                    }
                }
                return modelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<BookIssueModel> GetunreturnedBooks()
        {
            try
            {
                List<BookIssueModel> modelList = new List<BookIssueModel>();
                List<BookIssue> bookIssues = bookissueRepository.GetBookIssues();
                if (bookIssues != null && bookIssues.Any())
                {
                    BookIssueModel model = null;
                    foreach (var bookIssue in bookIssues)
                    {
                        if (bookIssue.ReturnDate.HasValue == false)
                        {
                            model = new BookIssueModel()
                            {
                                BookIssueID = bookIssue.BookIssueID,
                                BookID = bookIssue.BookID,
                                UserID = bookIssue.UserID,
                                IssueDate = bookIssue.IssueDate,
                                ReturnDate = bookIssue.ReturnDate,
                                FineAmount = bookIssue.FineAmount,
                                IssuerID = bookIssue.IssuerID
                            };
                            model.BookDetails = bookService.GetBookById(model.BookID);
                            model.UserDetails = userService.GetUserById(model.UserID);
                            model.IssuerDetails = userService.GetUserById(model.IssuerID);
                            modelList.Add(model);
                        }
                    }
                }
                return modelList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}

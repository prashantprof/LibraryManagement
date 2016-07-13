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
    public class AuthorService : IAuthorService
    {
        AuthorRepository authorRepository;
        BookRepository bookRepository;

        public AuthorService()
        {
            authorRepository = new AuthorRepository();
            bookRepository = new BookRepository();
        }
        public AuthorModel GetAuthorByID(int id)
        {
            try
            {
                AuthorModel model = null;
                Author author = authorRepository.GetAuthorByID(id);
                if (author != null)
                {
                    model = new AuthorModel()
                    {
                        AuthorID = author.AuthorID,
                        FirstName = author.FirstName,
                        LastName = author.LastName,
                        AboutAuthor = author.AboutAuthor
                    };
                }
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<AuthorModel> GetAuthors()
        {
            List<AuthorModel> modelList = null;
            try
            {
                List<Author> authors = authorRepository.GetAuthors();
                if (authors != null && authors.Any())
                {
                    modelList = authors.Select(author => new AuthorModel()
                    {
                        AuthorID = author.AuthorID,
                        FirstName = author.FirstName,
                        LastName = author.LastName,
                        AboutAuthor = author.AboutAuthor
                    }).ToList();

                    //AuthorModel model = null;
                    //foreach (var author in authors)
                    //{
                    //    model = new AuthorModel()
                    //    {
                    //        AuthorID = author.AuthorID,
                    //        FirstName = author.FirstName,
                    //        LastName = author.LastName,
                    //        AboutAuthor = author.AboutAuthor
                    //    };
                    //    modelList.Add(model);
                }
                return modelList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int SaveAuthor(AuthorModel newAuthor)
        {
            if (newAuthor != null)
            {
                if (newAuthor.AuthorID > 0)
                {
                    var author = authorRepository.GetAuthorByID(newAuthor.AuthorID);
                    if (author != null)
                    {
                        author.FirstName = newAuthor.FirstName;
                        author.LastName = newAuthor.LastName;
                        author.AboutAuthor = newAuthor.AboutAuthor;
                        authorRepository.UpdateAuthor(author);
                        return author.AuthorID;
                    }
                }
                else
                {
                    var author = new Author()
                    {
                        FirstName = newAuthor.FirstName,
                        LastName = newAuthor.LastName,
                        AboutAuthor = newAuthor.AboutAuthor
                    };
                    return authorRepository.AddAuthor(author);
                }
            }
            return 0;
        }
        public bool DeleteAuthor(int id)
        {
            if (id > 0)
                return authorRepository.DeleteAuthor(id);
            return false;
        }
        
    }
}

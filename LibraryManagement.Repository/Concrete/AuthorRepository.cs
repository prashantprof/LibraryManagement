using LibraryManagement.Repository.Abstract;
using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Concrete
{
    public class AuthorRepository : IAuthorRepository
    {
        LibraryManagementEntities db;
        public AuthorRepository()
        {
            db = new LibraryManagementEntities();
        }

        public Author GetAuthorByID(int id)
        {
            return db.Authors.Where(x => x.AuthorID.Equals(id)).FirstOrDefault();
        }

        public List<Author> GetAuthors()
        {
            return db.Authors.ToList();
        }

        public int AddAuthor(Author newAuthor)
        {
            db.Authors.Add(newAuthor);
            db.SaveChanges();
            return newAuthor.AuthorID;
        }


        public bool UpdateAuthor(Author author)
        {
            var existingAuthor = db.Authors.Where(x => x.AuthorID.Equals(author.AuthorID)).FirstOrDefault();
            if (existingAuthor != null )
            {
                existingAuthor.AuthorID=author.AuthorID;
                existingAuthor.FirstName = author.FirstName;
                existingAuthor.LastName = author.LastName;
                existingAuthor.AboutAuthor = author.AboutAuthor;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }


        public bool DeleteAuthor(int id)
        {
            var existingAuthor = db.Authors.Where(x => x.AuthorID.Equals(id)).FirstOrDefault();
            if (existingAuthor != null)
            {
                db.Authors.Remove(existingAuthor);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}

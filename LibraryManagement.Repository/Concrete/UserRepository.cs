using LibraryManagement.Repository.Abstract;
using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Concrete
{
    public class UserRepository : IUserRepository
    {
        LibraryManagementEntities db = null;

        public UserRepository()
        {
            db = new LibraryManagementEntities();
        }
        public User GetUserById(int id)
        {
            try
            {
                return db.Users.Where(x => x.UserID.Equals(id)).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetUserByEmailId(string emailid)
        {
            return db.Users.Where(x => x.EmaildID.Equals(emailid)).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public int AddUser(DatabaseEntities.User newUser)
        {
            db.Users.Add(newUser);
            db.SaveChanges();
            return newUser.UserID;
        }

        public bool UpdateUser(User user)
        {
            var existingUser = db.Users.Where(x => x.UserID.Equals(user.UserID)).FirstOrDefault();
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.EmaildID = user.EmaildID;
                existingUser.Password = user.Password;
                existingUser.MobileNumber = user.MobileNumber;
                existingUser.AddressOne = user.AddressOne;
                existingUser.AddressTwo = user.AddressTwo;
                existingUser.IsActive = user.IsActive;
                existingUser.Deposit = user.Deposit;
                existingUser.RoleID = user.RoleID;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool DeleteUser(int id)
        {
            var existingUser = db.Users.Where(x => x.UserID.Equals(id)).FirstOrDefault();
            if (existingUser != null)
            {
                db.Users.Remove(existingUser);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}

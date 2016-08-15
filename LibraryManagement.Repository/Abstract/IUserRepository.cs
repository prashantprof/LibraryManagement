using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Abstract
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUserByEmailId(string emailId);
        List<User> GetUsers();
        int AddUser(User newUser);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        bool GenerateRandomNumber(string emailID, int randomNum);
        bool MatchRandomNumber(int userID, int randomNum);
        bool DeleteRandomNumber(int userID, int randomNum);
    }

}

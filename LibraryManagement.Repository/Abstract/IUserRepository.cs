using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Abstract
{
    interface IUserRepository
    {
        User GetUserById(int id);

        User GetUserByEmailId(string emailid);

        List<User> GetUsers();

        int AddUser(User newUser);

        bool UpdateUser(User user);

        bool DeleteUser(int id);
    }
    
}

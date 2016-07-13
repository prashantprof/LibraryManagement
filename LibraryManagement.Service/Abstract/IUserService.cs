using LibraryManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Abstract
{
    public interface IUserService
    {
        UserModel GetUserById(int id);

        List<UserModel> GetUsers();

        int SaveUser(UserModel newUserModel);

        bool DeleteUser(int id);

        UserVerificationModel VerifyUser(string emailID, string password);

        List<UserModel> GetUsersByRoleID(int roleId);

    }
}

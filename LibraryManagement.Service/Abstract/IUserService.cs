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

        UserModel GetUserByEmailId(string id);

        List<UserModel> GetUsers();

        int SaveUser(UserModel newUserModel);

        bool DeleteUser(int id);

        UserVerificationModel VerifyUser(string emailID, string password);

        bool ResetPassword(string emailID, string oldPassword, string newPassword);

        string ResetPassword(string emailID, string newPassword);

        int GenerateRandomNumber(string userID);

        bool MatchRandomNumber(int userID, int randomNum);

        bool DeleteRandomNumber(int userID, int randomNum);
    }
}

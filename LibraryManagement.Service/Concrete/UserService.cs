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
    public class UserService : IUserService
    {
        UserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

        public UserModel GetUserById(int id)
        {
            try
            {
                UserModel model = null;
                User user = userRepository.GetUserById(id);
                if (user != null)
                {
                    model = new UserModel()
                    {
                        UserID = user.UserID,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        EmaildID = user.EmaildID,
                        Password = user.Password,
                        MobileNumber = user.MobileNumber,
                        AddressOne = user.AddressOne,
                        AddressTwo = user.AddressTwo,
                        IsActive = user.IsActive,
                        Deposit = user.Deposit
                    };
                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserModel GetUserByEmailId(string id)
        {
            try
            {
                UserModel model = null;
                User user = userRepository.GetUserByEmailId(id);
                if (user != null)
                {
                    model = new UserModel()
                    {
                        UserID = user.UserID,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        EmaildID = user.EmaildID,
                        Password = user.Password,
                        MobileNumber = user.MobileNumber,
                        AddressOne = user.AddressOne,
                        AddressTwo = user.AddressTwo,
                        IsActive = user.IsActive,
                        Deposit = user.Deposit
                    };
                }
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<UserModel> GetUsers()
        {
            List<UserModel> modelList = null;
            try
            {
                List<User> users = userRepository.GetUsers();
                if (users != null && users.Any())
                {
                    modelList = users.Select(user => new UserModel()
                    {
                        UserID = user.UserID,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        EmaildID = user.EmaildID,
                        Password = user.Password,
                        MobileNumber = user.MobileNumber,
                        AddressOne = user.AddressOne,
                        AddressTwo = user.AddressTwo,
                        IsActive = user.IsActive,
                        Deposit = user.Deposit
                    }).ToList();
                }
                return modelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveUser(UserModel newUser)
        {
            try
            {
                if (newUser != null)
                {
                    if (newUser.UserID > 0)
                    {
                        var user = userRepository.GetUserById(newUser.UserID);
                        if (user != null)
                        {
                            user.FirstName = newUser.FirstName;
                            user.LastName = newUser.LastName;
                            user.EmaildID = newUser.EmaildID;
                            user.Password = newUser.Password;
                            user.MobileNumber = newUser.MobileNumber;
                            user.AddressOne = newUser.AddressOne;
                            user.AddressTwo = newUser.AddressTwo;
                            user.IsActive = newUser.IsActive;
                            user.Deposit = newUser.Deposit;
                            userRepository.UpdateUser(user);
                            return user.UserID;
                        }
                    }
                    else
                    {
                        var user = new User()
                        {
                            FirstName = newUser.FirstName,
                            LastName = newUser.LastName,
                            EmaildID = newUser.EmaildID,
                            Password = newUser.Password,
                            MobileNumber = newUser.MobileNumber,
                            AddressOne = newUser.AddressOne,
                            AddressTwo = newUser.AddressTwo,
                            IsActive = newUser.IsActive,
                            Deposit = newUser.Deposit
                        };
                        return userRepository.AddUser(user);
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteUser(int id)
        {
            if (id > 0)
                return userRepository.DeleteUser(id);
            return false;
        }

        public UserVerificationModel VerifyUser(string emailID, string password)
        {
            UserVerificationModel model = new UserVerificationModel()
            {
                Status = UserVarificationStatus.None
            };
            model.UserDetails = null;
            //model.Message = string.Empty;
            try
            {
                User user = userRepository.GetUserByEmailId(emailID);
                if (user != null)
                {
                    if (user.Password.Trim().Equals(password.Trim()))
                    {
                        model.UserDetails = new UserModel()
                        {
                            AddressOne = user.AddressOne,
                            AddressTwo = user.AddressTwo,
                            Deposit = user.Deposit,
                            EmaildID = user.EmaildID,
                            FirstName = user.FirstName,
                            IsActive = user.IsActive,
                            LastName = user.LastName,
                            MobileNumber = user.MobileNumber,
                            Password = user.Password,
                            UserID = user.UserID
                        };
                    }
                    else
                        model.Status = UserVarificationStatus.PasswordIncorrect;
                }
                else
                    model.Status = UserVarificationStatus.UserUnregistered;

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ResetPassword(string emailID, string newPassword)
        {
            try
            {
                string oldPassword = string.Empty;
                var user = userRepository.GetUserByEmailId(emailID);

                if (user != null)
                {
                    oldPassword = user.Password;
                    user.Password = newPassword;
                    userRepository.UpdateUser(user);
                    return oldPassword;
                }
                return oldPassword;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ResetPassword(string emailID, string oldPassword, string newPassword)
        {
            try
            {
                var user = userRepository.GetUserByEmailId(emailID);

                if (user != null)
                {
                    var model = GetUserById(user.UserID);
                    if (model.Password.Equals(oldPassword))
                    {
                        model.Password = newPassword;
                        SaveUser(model);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GenerateRandomNumber(string emailID)
        {
            Random generator = new Random();
            int randomNum = generator.Next(100000, 999999);
            userRepository.GenerateRandomNumber(emailID, randomNum);
            return randomNum;
        }

        public bool MatchRandomNumber(int userID, int randomNum)
        {
            try
            {
                return userRepository.MatchRandomNumber(userID, randomNum);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteRandomNumber(int userID, int randomNum)
        {
            return userRepository.DeleteRandomNumber(userID, randomNum);
        }

    }
}

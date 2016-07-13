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
                        UserID = model.UserID,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        EmaildID = model.EmaildID,
                        Password = model.Password,
                        MobileNumber = model.MobileNumber,
                        AddressOne = model.AddressOne,
                        AddressTwo = model.AddressTwo,
                        IsActive = model.IsActive,
                        Deposit = model.Deposit,
                        RoleID = model.RoleID
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
                        Deposit = user.Deposit,
                        RoleID = user.RoleID
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
                            Deposit = newUser.Deposit,
                            RoleID = newUser.RoleID
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
            UserVerificationModel model = new UserVerificationModel();
            model.UserDetails = null;
            model.Message = string.Empty;
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
                            RoleID = user.RoleID,
                            UserID = user.UserID
                        };
                    }
                    else
                        model.Message = "Password is incorrect.";
                }
                else
                    model.Message = "Email ID is not registerd.";
                
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserModel> GetUsersByRoleID(int roleId)
        {
            try
            {
                List<UserModel> modelList = null;
                List<User> users = userRepository.GetUsersByRoleID(roleId);
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
                        Deposit = user.Deposit,
                        RoleID = user.RoleID
                    }).ToList();
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

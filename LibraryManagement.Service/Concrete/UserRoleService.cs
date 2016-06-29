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
    public class UserRoleService : IUserRoleService
    {
        UserRoleRepository userroleRepository;
        public UserRoleService()
        {
            userroleRepository = new UserRoleRepository();
        }

        public UserRoleModel GetUserRoleById(int id)
        {
            try
            {
                UserRoleModel model = null;
                UserRole userrole = userroleRepository.GetUserRoleById(id);
                if (userrole != null)
                {
                    model = new UserRoleModel()
                    {
                        RoleID = model.RoleID,
                        Role = model.Role
                    };
                }
                return model;
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<UserRoleModel> UserRoles()
        {
            try
            {
                List<UserRoleModel> modelList = null;
                List<UserRole> userroles = userroleRepository.GetUserRoles();
                if (userroles != null && userroles.Any())
                {
                    modelList = userroles.Select(userrole => new UserRoleModel()
                    {
                        RoleID = userrole.RoleID,
                        Role = userrole.Role
                    }).ToList();
                }
                return modelList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int SaveUserRole(UserRoleModel newUserRole)
        {
            try
            {
                if (newUserRole != null)
                {
                    if (newUserRole.RoleID > 0)
                    {
                        var userrole = userroleRepository.GetUserRoleById(newUserRole.RoleID);
                        if (userrole != null)
                        {
                            userrole.Role = newUserRole.Role;
                            userroleRepository.UpdateUserRole(userrole);
                            return userrole.RoleID;
                        }
                    }
                    else
                    {
                        var userrole = new UserRole()
                        {
                            Role = newUserRole.Role,
                            RoleID = newUserRole.RoleID
                        };
                        return userroleRepository.AddUserRole(userrole);
                    }
                }
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteUserRole(int id)
        {
            if (id > 0)
                return userroleRepository.DeleteUserRole(id);
            return false;
        }
    }
}

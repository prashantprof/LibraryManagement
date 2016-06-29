using LibraryManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Abstract
{
    public interface IUserRoleService
    {
        UserRoleModel GetUserRoleById(int id);

        List<UserRoleModel> UserRoles();

        int SaveUserRole(UserRoleModel newUserRole);

        bool DeleteUserRole(int id);
    }
}

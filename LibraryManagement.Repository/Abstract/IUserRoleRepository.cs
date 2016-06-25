using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Abstract
{
    interface IUserRoleRepository
    {
        UserRole GetUserRoleById(int id);

        List<UserRole> GetUserRoles();

        int AddUserRole(UserRole newUserRole);

        bool UpdateUserRole(UserRole userrole);

        bool DeleteUserRole(int id);

    }
}

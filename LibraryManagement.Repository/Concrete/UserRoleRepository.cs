using LibraryManagement.Repository.Abstract;
using LibraryManagement.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Concrete
{
    public class UserRoleRepository : IUserRoleRepository
    {
        LibraryManagementEntities db = null;

        public UserRoleRepository()
        {
            db = new LibraryManagementEntities();
        }

        public UserRole GetUserRoleById(int id)
        {
            return db.UserRoles.Where(x => x.RoleID.Equals(id)).FirstOrDefault();
        }

        public List<UserRole> GetUserRoles()
        {
            return db.UserRoles.ToList();
        }

        public int AddUserRole(UserRole newUserRole)
        {
            db.UserRoles.Add(newUserRole);
            db.SaveChanges();
            return newUserRole.RoleID;
        }

        public bool UpdateUserRole(UserRole userrole)
        {
            var existingUserRole = db.UserRoles.Where(x => x.RoleID.Equals(userrole.RoleID)).FirstOrDefault();
            if (existingUserRole != null)
            {
                existingUserRole.Role = userrole.Role;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool DeleteUserRole(int id)
        {
            var existingUserRole = db.UserRoles.Where(x => x.RoleID.Equals(id)).FirstOrDefault();
            if (existingUserRole != null)
            {
                db.UserRoles.Remove(existingUserRole);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}

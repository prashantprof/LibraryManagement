using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmaildID { get; set; }
        public string Password { get; set; }
        public byte[] MobileNumber { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public bool IsActive { get; set; }
        public Nullable<decimal> Deposit { get; set; }
        public int RoleID { get; set; }

    }
}

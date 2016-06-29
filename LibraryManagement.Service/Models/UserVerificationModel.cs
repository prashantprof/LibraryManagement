using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Models
{
    public class UserVerificationModel
    {
        public UserModel UserDetails { get; set; }

        public string Message { get; set; }
    }
}

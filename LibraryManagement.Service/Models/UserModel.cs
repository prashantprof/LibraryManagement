using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Service.Models
{
    public class UserModel
    {
        public int UserID { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email ID")]
        [EmailAddress(ErrorMessage="Invalid Emaid ID")]
        public string EmaildID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Password and Confirm password doesn't match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Mobile Number")]
        [MaxLength(10)]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$",ErrorMessage="Mobile number should be in 10 digits.")]
        public string MobileNumber { get; set; }

        [Required]
        [DisplayName("Address Line 1")]
        public string AddressOne { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressTwo { get; set; }

        public bool IsActive { get; set; }

        public decimal? Deposit { get; set; }
    }
}

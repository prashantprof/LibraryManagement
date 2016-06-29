using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Models
{
    public class BookIssueModel
    {
        public int BookIssueID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public System.DateTime IssueDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public Nullable<decimal> FineAmount { get; set; }
        public int IssuerID { get; set; }
    }
}

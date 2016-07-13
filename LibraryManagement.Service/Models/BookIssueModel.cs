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
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal? FineAmount { get; set; }
        public int IssuerID { get; set; }
        public BookModel BookDetails { get; set; }
        public UserModel IssuerDetails { get; set; }
        public UserModel UserDetails { get; set; }
    }
}

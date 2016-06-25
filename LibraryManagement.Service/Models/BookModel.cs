using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Models
{
    public class BookModel
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int AutherID { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }

        public AuthorModel AuthorDetails { get; set; }

        public CategoryModel CategoryDetails { get; set; }

    }
}

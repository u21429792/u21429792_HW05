using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21429792_HW05.Models
{
    public class OneBookVM
    {
        public List<BookDetailTable> BookDetailTables { get; set; }
        public List<Books> Books { get; set; }
        public List<Borrows> Borrows { get; set; }
        public List<Students> Students { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21429792_HW05.Models
{
    public class BookRecordsVM
    {
        // view model to start link between model lists
        public List<BookTable> Books { get; set; }
        public List<Authors> Authors { get; set; }
        public List<Types> Types { get; set; }
        public List<Borrows> Borrows { get; set; }
        public List<Students> Students { get; set; }
        public List<BookDetailTable> BookDetailTables { get; set; }
    }
}

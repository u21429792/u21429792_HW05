using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21429792_HW05.Models
{
    public class BookDetailTable
    {
        // creating properties to be used in the book borrowed view table
        public int BOID { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Student { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public int bookID { get; set; }

    }
}
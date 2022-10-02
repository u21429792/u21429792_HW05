using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21429792_HW05.Models
{
    public class Borrows
    {
        // creating properties for the model
        public int BOID { get; set; }
        public int BID { get; set; }
        public int SID { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
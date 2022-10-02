using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21429792_HW05.Models
{
    public class Books
    {
        // creating properties for the model
        public Books(int bID, int aID, int tID, string bTitle, int bPageCount, int bPoint)
        {
            BID = bID;
            AID = aID;
            TID = tID;
            BTitle = bTitle;
            BPageCount = bPageCount;
            BPoint = bPoint;
        }

        public int BID { get; set; }
        public int AID { get; set; }
        public int TID { get; set; }
        public string BTitle { get; set; }
        public int BPageCount { get; set; }
        public int BPoint { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21429792_HW05.Models
{
    public class Students
    {
        // creating properties for the model
        public int SID { get; set; }
        public string SName { get; set; }
        public string SSurname { get; set; }
        public DateTime SDOB { get; set; }
        public string SGender { get; set; }
        public string SClass { get; set; }
        public int SPoint { get; set; }
        public int BOID { get; set; }
    }
}
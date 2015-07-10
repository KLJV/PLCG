using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLCG.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationCity { get; set; }
        public string LocationZip { get; set; }
        public string LocationState { get; set; }
        public string LocationCountry { get; set; }
        public int LocationRadius { get; set; }
    }
}
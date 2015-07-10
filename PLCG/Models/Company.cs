using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLCG.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public int CompanyLocationID { get; set; }
        public int CompanyTechnologyID { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class PersonVM
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
    }
}
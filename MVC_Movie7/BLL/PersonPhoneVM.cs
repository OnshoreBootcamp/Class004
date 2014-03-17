using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class PersonPhoneVM
    {
        public int id { get; set; }
        //Person
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
        //Phone
        public string number { get; set; }
        //Type
        public string type { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class PersonAddressVM
    {
        public int id { get; set; }
        //Person
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
        //Address
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        //Type
        public string type { get; set; }
    }
}
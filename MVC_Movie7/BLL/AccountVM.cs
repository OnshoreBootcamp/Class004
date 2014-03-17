using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountVM
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
        public string addressType { get; set; }
        //Phone
        public string number { get; set; }
        //Type
        public string phoneType { get; set; }
        //Movie
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        public string genre { get; set; }
    }
}

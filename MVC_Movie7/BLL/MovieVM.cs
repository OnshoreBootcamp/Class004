using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class MovieVM
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        public string genre { get; set; }
    }
}
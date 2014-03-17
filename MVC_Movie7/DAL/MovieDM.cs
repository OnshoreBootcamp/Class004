using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
    public class MovieDM
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        public int genreId { get; set; }
    }
}
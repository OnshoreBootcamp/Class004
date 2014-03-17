using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMovie.Models
{
    public class Movie
    {
        public int id { get; set; }
        [Required(ErrorMessage="Title is required")]
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public string genre { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MinLength(8)]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Range(0,20)]
        public int NumberInStock { get; set; }
        public Genre Genre { get; set; }
        public short GenreId { get; set; }

        public Movie()
        {
            ReleaseDate=new DateTime();
            NumberInStock = 0;
        }
    }
}
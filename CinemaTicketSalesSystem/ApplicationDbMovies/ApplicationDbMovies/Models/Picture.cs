using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDbMovies.Models
{
    public class Picture
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public int MovieId { get; set; }
    }
}

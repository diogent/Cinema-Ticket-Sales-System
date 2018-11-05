using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDbMovies.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int MovieId { get; set; }
    }
}

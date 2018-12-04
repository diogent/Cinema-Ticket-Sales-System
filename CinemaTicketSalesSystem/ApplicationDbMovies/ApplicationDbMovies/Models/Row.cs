using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDbMovies.Models
{
    public class Row
    {
        public int Id { get; set; }               
        public bool Type { get; set; }
        public int Number { get; set; }
        public int HallId { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }

        public Row()
        {
            Seats = new List<Seat>();
        }
    }
}

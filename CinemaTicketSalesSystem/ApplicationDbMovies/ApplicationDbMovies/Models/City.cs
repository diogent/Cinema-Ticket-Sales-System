using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDbMovies.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string CityName { get; set; }

        public virtual ICollection<CinemaAddress> Addresses { get; set; }
        
        public City()
        {
            Addresses = new List<CinemaAddress>();
        }
    }
}

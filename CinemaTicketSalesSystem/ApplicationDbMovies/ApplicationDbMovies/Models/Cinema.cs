using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDbMovies.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Key, ForeignKey("Address")]
        public int AddressId { get; set; }
        
        public virtual CinemaAddress Address { get; set; }

        [Required]
        [StringLength(255)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Hall> Halls { get; set; }

        public Cinema()
        {
            Halls = new List<Hall>();
        }
    }
}

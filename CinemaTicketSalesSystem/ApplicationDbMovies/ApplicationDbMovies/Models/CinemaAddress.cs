using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDbMovies.Models
{
    public class CinemaAddress
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string AddressName { get; set; }
        
        public int CityId { get; set; }

        [Required]
        public virtual City City { get; set; }

        [Key, ForeignKey("Cinema")]
        public int CinemaId { get; set; }

        [Required]
        public virtual Cinema Cinema { get; set; }
    }
}

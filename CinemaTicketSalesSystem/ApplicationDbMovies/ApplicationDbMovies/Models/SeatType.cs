using System.ComponentModel.DataAnnotations;

namespace ApplicationDbMovies.Models
{
    public class SeatType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Type { get; set; }
    }
}

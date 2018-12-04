using System.ComponentModel.DataAnnotations;

namespace ApplicationDbMovies.Models
{
    public class Hall
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int CinemaId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ApplicationDbMovies.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string Time { get; set; }

        public float Coefficient { get; set; }
    }
}

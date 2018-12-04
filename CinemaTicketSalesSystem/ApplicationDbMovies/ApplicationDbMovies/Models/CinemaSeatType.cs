using System.ComponentModel.DataAnnotations;

namespace ApplicationDbMovies.Models
{
    public class CinemaSeatType
    {
        public int Id { get; set; }
        public int SeatTypeId { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999.99)]
        public decimal Price { get; set; }
    }
}

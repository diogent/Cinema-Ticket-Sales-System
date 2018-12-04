namespace ApplicationDbMovies.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int SeatTypeId { get; set; }
        public int CinemaSeatTypeId { get; set; }
        public int RowId { get; set; }
    }
}
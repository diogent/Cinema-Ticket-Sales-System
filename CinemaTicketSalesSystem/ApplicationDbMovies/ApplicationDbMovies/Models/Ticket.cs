namespace ApplicationDbMovies.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int RowId { get; set; }
        public int SeatId { get; set; }       
    }
}
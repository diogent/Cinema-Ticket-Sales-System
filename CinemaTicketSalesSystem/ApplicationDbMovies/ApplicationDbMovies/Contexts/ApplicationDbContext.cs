using System.Data.Entity;
using ApplicationDbMovies.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApplicationDbMovies.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<CinemaAddress> Addresses { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaSeatType> CinemaSeatTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatType> SeatTypes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public ApplicationDbContext() : base("IdentityDb")
        {
            Database.SetInitializer(new MoviesInit());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

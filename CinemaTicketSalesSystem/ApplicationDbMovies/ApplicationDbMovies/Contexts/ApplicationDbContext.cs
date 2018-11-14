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

using System.Data.Entity.ModelConfiguration;
using ApplicationDbMovies.Models;

namespace ApplicationDbMovies.Configurations
{
    public class MovieGenreConfig : EntityTypeConfiguration<Genre>
    {
        public MovieGenreConfig()
        {
            this.HasMany(m => m.Movies)
                .WithMany(g => g.Genres)
                .Map(t => t.MapLeftKey("GenreId")
                .MapRightKey("MovieId")
                .ToTable("MovieGenre"));
        }
    }
}

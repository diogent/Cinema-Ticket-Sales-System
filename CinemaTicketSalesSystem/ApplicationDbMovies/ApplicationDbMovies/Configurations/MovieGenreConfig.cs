using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ApplicationDbMovies.Models;
using System.Data.Entity;

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

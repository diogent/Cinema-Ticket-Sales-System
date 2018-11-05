using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity;

namespace MoviesData.Models
{
    public class MovieGenreConfig : EntityTypeConfiguration<Movie>
    {
        public MovieGenreConfig(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasMany(m => m.Movies)
                .WithMany(g => g.Genres)
                .Map(t => t.MapLeftKey("GenreId")
                .MapRightKey("MovieId")
                .ToTable("MovieGenre"));
        }
    }
}
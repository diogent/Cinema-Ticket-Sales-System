using ApplicationDbMovies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDbMovies.Configurations
{
    public class MovieActorConfig : EntityTypeConfiguration<Actor>
    {
        public MovieActorConfig()
        {
            this.HasMany(m => m.Movies)
                .WithMany(g => g.Actors)
                .Map(t => t.MapLeftKey("ActorId")
                .MapRightKey("MovieId")
                .ToTable("MovieActor"));
        }
    }
}

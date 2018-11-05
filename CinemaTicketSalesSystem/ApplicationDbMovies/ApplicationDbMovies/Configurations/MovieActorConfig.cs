using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity;
using ApplicationDbMovies.Models;

namespace ApplicationDbMovies.Configurations
{
    public class MovieActorConfig : EntityTypeConfiguration<Actor>
    {
        public MovieActorConfig()
        {
            this.HasMany(m => m.Movies)
                .WithMany(a => a.Actors)
                .Map(t => t.MapLeftKey("ActorId")
                .MapRightKey("MovieId")
                .ToTable("MovieActor"));
        }
    }
}

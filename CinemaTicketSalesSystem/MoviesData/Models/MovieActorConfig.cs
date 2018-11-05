using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity;

namespace MoviesData.Models
{
    public class MovieActorConfig : EntityTypeConfiguration<Actor>
    {
        public MovieActorConfig ()
        {
            this.HasMany(m => Movies)
                .WithMany(a => Actors)
                .Map(t => t.MapLeftKey("ActorId")
                .MapRightKey("MovieId")
                .ToTable("MovieActor"));
        }
    }
}
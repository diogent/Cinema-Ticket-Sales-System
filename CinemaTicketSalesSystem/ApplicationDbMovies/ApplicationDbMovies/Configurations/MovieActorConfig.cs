using System.Data.Entity.ModelConfiguration;
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

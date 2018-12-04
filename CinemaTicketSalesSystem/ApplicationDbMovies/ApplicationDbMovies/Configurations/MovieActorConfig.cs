using ApplicationDbMovies.Models;
using System.Data.Entity.ModelConfiguration;

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

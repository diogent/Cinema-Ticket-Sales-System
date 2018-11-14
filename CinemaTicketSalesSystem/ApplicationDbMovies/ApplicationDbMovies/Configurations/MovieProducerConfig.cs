using System.Data.Entity.ModelConfiguration;
using ApplicationDbMovies.Models;

namespace ApplicationDbMovies.Configurations
{
    public class MovieProducerConfig : EntityTypeConfiguration<Producer>
    {
        public MovieProducerConfig()
        {
            this.HasMany(m => m.Movies)
                .WithMany(g => g.Producers)
                .Map(t => t.MapLeftKey("ProducerId")
                .MapRightKey("MovieId")
                .ToTable("MovieProducer"));
        }
    }
}

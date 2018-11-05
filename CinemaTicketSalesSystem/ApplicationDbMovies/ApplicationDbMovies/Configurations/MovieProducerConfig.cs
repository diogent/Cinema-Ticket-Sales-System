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

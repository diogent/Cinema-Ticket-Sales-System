using ApplicationDbMovies.Models;
using System.Data.Entity.ModelConfiguration;

namespace ApplicationDbMovies.Configurations
{
    public class AddressCityConfig : EntityTypeConfiguration<City>
    {
        public AddressCityConfig()
        {
            this.HasMany(t => t.Addresses)
                .WithRequired(e => e.City)
                .HasForeignKey(x => x.CityId);
        }
    }
}

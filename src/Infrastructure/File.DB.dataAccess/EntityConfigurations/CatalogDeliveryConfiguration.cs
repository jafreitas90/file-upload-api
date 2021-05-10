using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace File.dataAccess.EntityConfigurations
{
    public class CatalogDeliveryConfiguration : IEntityTypeConfiguration<CatalogDelivery>
    {
        public void Configure(EntityTypeBuilder<CatalogDelivery> builder)
        {
            builder.HasIndex(p => p.DeliveryIn).IsUnique();
        }
    }
}

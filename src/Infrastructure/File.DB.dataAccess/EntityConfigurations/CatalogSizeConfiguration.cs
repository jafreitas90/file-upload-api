using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace File.dataAccess.EntityConfigurations
{
    public class CatalogSizeConfiguration : IEntityTypeConfiguration<CatalogSize>
    {
        public void Configure(EntityTypeBuilder<CatalogSize> builder)
        {
            builder.HasIndex(p => p.Size).IsUnique();
        }
    }
}

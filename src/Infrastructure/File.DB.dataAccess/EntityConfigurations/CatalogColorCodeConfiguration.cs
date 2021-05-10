using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace File.dataAccess.EntityConfigurations
{
    public class CatalogColorCodeConfiguration : IEntityTypeConfiguration<CatalogColorCode>
    {
        public void Configure(EntityTypeBuilder<CatalogColorCode> builder)
        {
            builder.HasIndex(p => p.Code).IsUnique();
        }
    }
}

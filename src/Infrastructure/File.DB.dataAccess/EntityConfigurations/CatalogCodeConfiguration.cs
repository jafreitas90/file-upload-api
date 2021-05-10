using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace File.dataAccess.EntityConfigurations
{
    public class CatalogCodeConfiguration : IEntityTypeConfiguration<CatalogCode>
    {
        public void Configure(EntityTypeBuilder<CatalogCode> builder)
        {
            builder.HasIndex(p => p.Code).IsUnique();
        }
    }
}

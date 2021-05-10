using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace File.dataAccess.EntityConfigurations
{
    class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            var codeNavigation = builder.Metadata.FindNavigation(nameof(CatalogItem.Code));
            codeNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var colorNavigation = builder.Metadata.FindNavigation(nameof(CatalogItem.Color));
            colorNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var colorCodeNavigation = builder.Metadata.FindNavigation(nameof(CatalogItem.ColorCode));
            colorCodeNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var deliveryNavigation = builder.Metadata.FindNavigation(nameof(CatalogItem.Delivery));
            deliveryNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var typeNavigation = builder.Metadata.FindNavigation(nameof(CatalogItem.Type));
            typeNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var sizeNavigation = builder.Metadata.FindNavigation(nameof(CatalogItem.Size));
            sizeNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            //builder.Entity<CatalogCode>(entity => {
            //    entity.HasIndex(e => e.Code).IsUnique();
            //});
        }
    }
}
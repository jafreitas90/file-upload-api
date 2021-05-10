using System.Reflection;
using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace File.DB.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "Tenant";
        public DbSet<CatalogCode> CatalogCodes { get; set; }
        public DbSet<CatalogSize> CatalogSizes { get; set; }
        public DbSet<CatalogColor> CatalogColors { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogDelivery> CatalogDeliveries { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogColorCode> CatalogColorCodes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
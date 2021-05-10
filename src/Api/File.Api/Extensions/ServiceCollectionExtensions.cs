using File.DB.DataAccess;
using File.DB.DataAccess.Data;
using File.Domain.Contracts;
using File.Json.DataAccess;
using File.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace File.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureInMemoryDatabases(this IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<ApplicationDbContext>(c =>
                c.UseInMemoryDatabase("Catalog"));
        }

        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<ApplicationSettings>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICatalogItemRepository, CatalogItemRepository>();
            services.AddScoped<ICatalogItemRepository, CatalogItemJsonRepository>();
            services.AddScoped<ICatalogTypeRepository, CatalogTypeRepository>();
            services.AddScoped<ICatalogSizeRepository, CatalogSizeRepository>();
            services.AddScoped<ICatalogDeliveryRepository, CatalogDeliveryRepository>();
            services.AddScoped<ICatalogColorRepository, CatalogColorRepository>();
            services.AddScoped<ICatalogColorCodeRepository, CatalogColorCodeRepository>();
            services.AddScoped<ICatalogCodeRepository, CatalogCodeRepository>();
            services.AddScoped<ICatalogCodeRepository, CatalogCodeRepository>();            
        }
    }
}

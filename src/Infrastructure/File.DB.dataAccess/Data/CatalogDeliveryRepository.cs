using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Contracts;
using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace File.DB.DataAccess.Data
{
    public class CatalogDeliveryRepository : BaseRepository<CatalogDelivery>, ICatalogDeliveryRepository
    {
        public CatalogDeliveryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<CatalogDelivery>> LoadAllItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.CatalogDeliveries.ToListAsync(cancellationToken);
        }
    }
}
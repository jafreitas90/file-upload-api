using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Contracts;
using File.Domain.Entities;

namespace File.DB.DataAccess.Data
{
    public class CatalogItemRepository : BaseRepository<CatalogItem>, ICatalogItemRepository
    {
        public CatalogItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddItemsAsync(IEnumerable<CatalogItem> items, CancellationToken cancellationToken = default)
        {
            _context.CatalogItems.AddRange(items);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
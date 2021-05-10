using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Contracts;
using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace File.DB.DataAccess.Data
{
    public class CatalogSizeRepository : BaseRepository<CatalogSize>, ICatalogSizeRepository
    {
        public CatalogSizeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<CatalogSize>> LoadAllItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.CatalogSizes.ToListAsync(cancellationToken);
        }
    }
}
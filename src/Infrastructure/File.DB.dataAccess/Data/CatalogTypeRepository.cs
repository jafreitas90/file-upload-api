using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Contracts;
using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace File.DB.DataAccess.Data
{
    public class CatalogTypeRepository : BaseRepository<CatalogType>, ICatalogTypeRepository
    {
        public CatalogTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<CatalogType>> LoadAllItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.CatalogTypes.ToListAsync(cancellationToken);
        }
    }
}
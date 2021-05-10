using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Contracts;
using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace File.DB.DataAccess.Data
{
    public class CatalogColorRepository : BaseRepository<CatalogColor>, ICatalogColorRepository
    {
        public CatalogColorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<CatalogColor>> LoadAllItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.CatalogColors.ToListAsync(cancellationToken);
        }
    }
}
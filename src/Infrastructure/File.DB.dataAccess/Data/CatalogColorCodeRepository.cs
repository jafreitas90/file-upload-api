using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Contracts;
using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace File.DB.DataAccess.Data
{
    public class CatalogColorCodeRepository : BaseRepository<CatalogColorCode>, ICatalogColorCodeRepository
    {
        public CatalogColorCodeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<CatalogColorCode>> LoadAllItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.CatalogColorCodes.ToListAsync(cancellationToken);
        }
    }
}
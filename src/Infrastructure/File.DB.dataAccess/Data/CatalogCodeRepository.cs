using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Contracts;
using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace File.DB.DataAccess.Data
{
    public class CatalogCodeRepository : BaseRepository<CatalogCode>, ICatalogCodeRepository
    {
        public CatalogCodeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<CatalogCode>> LoadAllItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.CatalogCodes.ToListAsync(cancellationToken);
        }
    }
}
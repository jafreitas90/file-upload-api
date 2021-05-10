using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Entities;

namespace File.Domain.Contracts
{
    public interface ICatalogColorCodeRepository : IRepository<CatalogColorCode>
    {
        Task<IReadOnlyList<CatalogColorCode>> LoadAllItemsAsync(CancellationToken cancellationToken = default);
    }
}

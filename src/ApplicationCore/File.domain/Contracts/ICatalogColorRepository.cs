using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Entities;

namespace File.Domain.Contracts
{
    public interface ICatalogColorRepository : IRepository<CatalogColor>
    {
        Task<IReadOnlyList<CatalogColor>> LoadAllItemsAsync(CancellationToken cancellationToken = default);
    }
}

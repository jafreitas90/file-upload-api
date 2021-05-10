using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Entities;

namespace File.Domain.Contracts
{
    public interface ICatalogSizeRepository : IRepository<CatalogSize>
    {
        Task<IReadOnlyList<CatalogSize>> LoadAllItemsAsync(CancellationToken cancellationToken = default);
    }
}

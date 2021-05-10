using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Entities;

namespace File.Domain.Contracts
{
    public interface ICatalogCodeRepository : IRepository<CatalogCode>
    {
        Task<IReadOnlyList<CatalogCode>> LoadAllItemsAsync(CancellationToken cancellationToken = default);
    }
}

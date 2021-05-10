using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Entities;

namespace File.Domain.Contracts
{
    public interface ICatalogItemRepository : IRepository<CatalogItem>
    {
        Task AddItemsAsync(IEnumerable<CatalogItem> items, CancellationToken cancellationToken = default);
    }
}

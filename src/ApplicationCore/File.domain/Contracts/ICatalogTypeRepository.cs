using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Entities;

namespace File.Domain.Contracts
{
    public interface ICatalogTypeRepository : IRepository<CatalogType>
    {
        Task<IReadOnlyList<CatalogType>> LoadAllItemsAsync(CancellationToken cancellationToken = default);
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Entities;

namespace File.Domain.Contracts
{
    public interface ICatalogDeliveryRepository : IRepository<CatalogDelivery>
    {
        Task<IReadOnlyList<CatalogDelivery>> LoadAllItemsAsync(CancellationToken cancellationToken = default);
    }
}

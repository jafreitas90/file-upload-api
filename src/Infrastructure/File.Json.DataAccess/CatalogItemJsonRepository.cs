using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Contracts;
using File.Domain.Entities;
using File.Shared.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace File.Json.DataAccess
{
    public class CatalogItemJsonRepository : ICatalogItemRepository
    {
        private readonly ILogger<CatalogItemJsonRepository> _logger;
        private readonly ApplicationSettings _applicationSettings;
        public CatalogItemJsonRepository(ILogger<CatalogItemJsonRepository> logger, ApplicationSettings applicationSettings)
        {
            _logger = logger;
            _applicationSettings = applicationSettings;
        }

        public Task<CatalogItem> AddAsync(CatalogItem entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task AddItemsAsync(IEnumerable<CatalogItem> items, CancellationToken cancellationToken = default)
        {
            try
            {
                string path = _applicationSettings.StoredFilesPath;
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(file, items);
                }
                return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public Task<CatalogItem> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CatalogItem entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using File.Domain.Contracts;
using File.Domain.Entities;
using File.Service.Extensions;
using File.Service.Models.Csv;
using File.Service.Models.Request.File;
using File.Service.Utils;
using File.Shared.Utils;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using File.Service.Validations.File;

namespace File.Service.Features.Commands.File
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileRequest, Unit>
    {

        private readonly ICatalogTypeRepository _catalogTypeRepository;
        private readonly ICatalogSizeRepository _catalogSizeRepository;
        private readonly ICatalogDeliveryRepository _catalogDelivery;
        private readonly ICatalogColorRepository _catalogColorRepository;
        private readonly ICatalogColorCodeRepository _catalogColorCodeRepository;
        private readonly ICatalogCodeRepository _catalogCodeRepository;
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly ILogger<UploadFileCommandHandler> _logger; 
        private readonly ApplicationSettings _applicationSettings;
        private readonly FormOptions _defaultFormOptions = new FormOptions();

        private List<CatalogType> catalogTypeList = new List<CatalogType>();
        private List<CatalogSize> catalogSizeList = new List<CatalogSize>();
        private List<CatalogDelivery> catalogDeliveryList = new List<CatalogDelivery>();
        private List<CatalogColor> catalogColorList = new List<CatalogColor>();
        private List<CatalogColorCode> catalogColorCodeList = new List<CatalogColorCode>();
        private List<CatalogCode> catalogCodeList = new List<CatalogCode>();
        private List<CatalogType> catalogTypes = new List<CatalogType>();

        public UploadFileCommandHandler(
            ApplicationSettings applicationSettings, 
            ILogger<UploadFileCommandHandler> logger,
            ICatalogItemRepository catalogItemRepository,
            ICatalogTypeRepository catalogTypeRepository,
            ICatalogSizeRepository catalogSizeRepository,
            ICatalogDeliveryRepository catalogDelivery,
            ICatalogColorRepository catalogColorRepository,
            ICatalogColorCodeRepository catalogColorCodeRepository, 
            ICatalogCodeRepository catalogCodeRepository)
        {
            _logger = logger;
            _applicationSettings = applicationSettings;
            _catalogItemRepository = catalogItemRepository;
            _catalogTypeRepository = catalogTypeRepository;
            _catalogSizeRepository = catalogSizeRepository;
            _catalogDelivery = catalogDelivery;
            _catalogColorRepository = catalogColorRepository;
            _catalogColorCodeRepository = catalogColorCodeRepository;
            _catalogCodeRepository = catalogCodeRepository;
        }

        public async Task<Unit> Handle(UploadFileRequest request, CancellationToken cancellationToken = default)
        {
            request.Validate();

            var contentType = request.ContentType;
            var body = request.Body;

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(contentType),
                _defaultFormOptions.MultipartBoundaryLengthLimit);

            var reader = new MultipartReader(boundary, body);
            var section = await reader.ReadNextSectionAsync();

            // load data
            await LoadDataAsync(cancellationToken);

            while (section != null)
            {
                var streamedFileContent = await FileHelpers.ProcessStreamedFile(section, _applicationSettings.FileSizeLimit);
                var records = CsvHelpers.GetRecords<CsvFile>(streamedFileContent);

                var items = records.ToCatalogItems(
                    catalogTypeList, catalogSizeList, catalogDeliveryList, 
                    catalogColorList, catalogColorCodeList, catalogCodeList);

                await _catalogItemRepository.AddItemsAsync(items, cancellationToken);

                section = await reader.ReadNextSectionAsync();
            }


            return Unit.Value;
        }

        // these tables should be small tables
        private async Task LoadDataAsync(CancellationToken cancellationToken = default)
        {
            catalogTypeList = (await _catalogTypeRepository.LoadAllItemsAsync(cancellationToken)).ToList();
            catalogSizeList = (await _catalogSizeRepository.LoadAllItemsAsync(cancellationToken)).ToList();
            catalogDeliveryList = (await _catalogDelivery.LoadAllItemsAsync(cancellationToken)).ToList();
            catalogColorList = (await _catalogColorRepository.LoadAllItemsAsync(cancellationToken)).ToList();
            catalogColorCodeList = (await _catalogColorCodeRepository.LoadAllItemsAsync(cancellationToken)).ToList();
            catalogCodeList = (await _catalogCodeRepository.LoadAllItemsAsync(cancellationToken)).ToList();
        }
    }
}

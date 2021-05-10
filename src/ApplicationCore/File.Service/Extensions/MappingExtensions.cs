using System.Collections.Generic;
using File.Domain.Entities;
using File.Service.Models.Csv;
using System.Linq;

namespace File.Service.Extensions
{
    public static class MappingExtensions
    {
        public static IEnumerable<CatalogItem> ToCatalogItems(
            this IEnumerable<CsvFile> records,
            List<CatalogType> catalogTypeList,
            List<CatalogSize> catalogSizeList,
            List<CatalogDelivery> catalogDeliveryList,
            List<CatalogColor> catalogColorList,
            List<CatalogColorCode> catalogColorCodeList,
            List<CatalogCode> catalogCodeList)
        {
            var items = new List<CatalogItem>();
            foreach(var record in records)
            {
                string key = record.Key;
                string description = record.Description;
                var price = record.Price;
                var discount = record.DiscountPrice;
                var code = catalogCodeList.FirstOrDefault(x => x.Code.Equals(record.ArtikelCode));
                var color = catalogColorList.FirstOrDefault(x => x.Color.Equals(record.ArtikelCode));
                var colorCode = catalogColorCodeList.FirstOrDefault(x => x.Code.Equals(record.ColorCode));
                var delivery = catalogDeliveryList.FirstOrDefault(x => x.DeliveryIn.Equals(record.DeliveredIn));
                var type = catalogTypeList.FirstOrDefault(x => x.Type.Equals(record.Q1));
                var size = catalogSizeList.FirstOrDefault(x => x.Size.Equals(record.Size));

                if (code == null)
                {
                    code = new CatalogCode(record.ArtikelCode);
                    catalogCodeList.Add(code);
                }
                if(color == null)
                {
                    color = new CatalogColor(record.Color);
                    catalogColorList.Add(color);
                }
                if(colorCode == null)
                {
                    colorCode = new CatalogColorCode(record.ColorCode);
                    catalogColorCodeList.Add(colorCode);
                }
                if(delivery == null)
                {
                    delivery = new CatalogDelivery(record.DeliveredIn);
                    catalogDeliveryList.Add(delivery);
                }
                if (delivery == null)
                {
                    delivery = new CatalogDelivery(record.DeliveredIn);
                    catalogDeliveryList.Add(delivery);
                }
                if(type == null)
                {
                    type = new CatalogType(record.Q1);
                    catalogTypeList.Add(type);
                }
                items.Add(new CatalogItem(key, description, price, discount, code, type, color, size, delivery, colorCode));
            }
            return items;
        }
    }
}

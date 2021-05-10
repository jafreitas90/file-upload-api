namespace File.Domain.Entities
{
    public class CatalogItem : BaseEntity
    {   
        public string Key { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal Discount { get; private set; }

        public CatalogCode Code { get; private set; }
        public CatalogType Type { get; private set; }
        public CatalogColor Color { get; private set; }
        public CatalogSize Size { get; private set; }
        public CatalogDelivery Delivery { get; private set; }
        public CatalogColorCode ColorCode { get; private set; }

        private CatalogItem() { }

        public CatalogItem(string key, string description, decimal price, decimal discount,
            CatalogCode code, CatalogType type, CatalogColor color, 
            CatalogSize size, CatalogDelivery delivery, CatalogColorCode colorCode)
        {
            Key = key;
            Description = description;
            Price = price;
            Discount = discount;
            Code = code;
            Type = type;
            Color = color;
            Size = size;
            Delivery = delivery;
            ColorCode = colorCode;
        }
    }
}

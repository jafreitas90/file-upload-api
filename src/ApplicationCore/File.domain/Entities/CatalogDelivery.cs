namespace File.Domain.Entities
{
    public class CatalogDelivery : BaseEntity
    {
        public string DeliveryIn { get; private set; }
        public CatalogDelivery(string deliveryIn)
        {
            DeliveryIn = deliveryIn;
        }
    }
}

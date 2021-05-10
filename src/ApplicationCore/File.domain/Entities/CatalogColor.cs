namespace File.Domain.Entities
{
    public class CatalogColor : BaseEntity
    {
        public string Color { get; private set; }
        public CatalogColor(string color)
        {
            Color = color;
        }
    }
}

namespace File.Domain.Entities
{
    public class CatalogSize : BaseEntity
    {
        public int Size{ get; private set; }
        public CatalogSize(int size)
        {
            Size = size;
        }
    }
}

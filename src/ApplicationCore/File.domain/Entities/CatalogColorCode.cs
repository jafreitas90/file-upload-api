namespace File.Domain.Entities
{
    public class CatalogColorCode : BaseEntity
    {
        public string Code { get; private set; }
        public CatalogColorCode(string code)
        {
            Code = code;
        }
    }
}

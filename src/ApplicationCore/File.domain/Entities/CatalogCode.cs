namespace File.Domain.Entities
{
    public class CatalogCode : BaseEntity
    {
        public string Code { get; private set; }
        public CatalogCode(string code)
        {
            Code = code;
        }
    }
}

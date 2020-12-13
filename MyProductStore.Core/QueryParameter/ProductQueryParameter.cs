namespace MyProductStore.Core.QueryParameter
{
    public class ProductQueryParameter : QueryStringParameters
    {
        public string Name { get; set; }

        public string Sku { get; set; }
    }
}

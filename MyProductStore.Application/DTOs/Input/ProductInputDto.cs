namespace MyProductStore.Application.DTOs.Input
{
    public class ProductInputDto
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public short Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}

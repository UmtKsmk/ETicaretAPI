namespace ETicaretAPI.Domain.Entities
{
    public class ProductImageFile : File
    {
        public bool ShowCase { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

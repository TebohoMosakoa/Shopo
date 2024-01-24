using CatalogApi.Models;

namespace CatalogApi.DTOs
{
    public class BrandDTO : EntityBase
    {
        public List<ProductDTO> Products { get; set; }
    }
}

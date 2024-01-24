using CatalogApi.Models;

namespace CatalogApi.DTOs
{
    public class CategoryDTO : EntityBase
    {
        public List<ProductDTO> Products { get; set; }
    }
}

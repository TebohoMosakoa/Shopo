using CatalogApi.Models;

namespace CatalogApi.DTOs
{
    public class DepartmentDTO : EntityBase
    {
        public List<ProductDTO> Products { get; set; }
    }
}

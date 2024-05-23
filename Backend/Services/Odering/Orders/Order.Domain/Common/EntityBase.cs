using System.ComponentModel.DataAnnotations;

namespace Order.Domain.Common
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public string DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}

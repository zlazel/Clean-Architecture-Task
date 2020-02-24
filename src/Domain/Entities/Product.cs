using Clean_Architecture_Task.Domain.Common;

namespace Clean_Architecture_Task.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BarCode { get; set; }
        public decimal SellingPrice { get; set; }
        public bool Disabled { get; set; }
        public bool Deleted { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

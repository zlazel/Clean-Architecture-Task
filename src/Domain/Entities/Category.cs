using Clean_Architecture_Task.Domain.Common;
using System;
using System.Collections.Generic;

namespace Clean_Architecture_Task.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Disabled { get; set; }
        public bool Deleted { get; set; }
        public IList<Product> Products { get; private set; }
    }
}

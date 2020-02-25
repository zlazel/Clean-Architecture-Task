using AutoMapper;
using Clean_Architecture_Task.Application.Common.Mappings;
using Clean_Architecture_Task.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Canteen.Application.Products.Models
{
    public class ProductLiDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SellingPrice { get; set; }
        public bool Disabled { get; set; }

        public string CategoryName { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Product, ProductLiDto>()
                   .ForMember(b => b.CategoryName,
                           opt => opt.MapFrom(v => v.Category != null ?
                               v.Category.Name : string.Empty));
        }
    }
}

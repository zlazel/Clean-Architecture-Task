using AutoMapper;
using Canteen.Application.Products.Models;
using Clean_Architecture_Task.Application.Common.Mappings;
using Clean_Architecture_Task.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Canteen.Application.Categories.Models
{
    public class CategoryDto : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Disabled { get; set; }

    }
}

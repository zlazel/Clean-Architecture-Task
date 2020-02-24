using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen.Application.Products.Commands
{
    public class UpdateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SellingPrice { get; set; }
        public bool Disabled { get; set; }
        public int CategoryId { get; set; }
    }
}

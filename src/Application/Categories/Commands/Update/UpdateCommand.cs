using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen.Application.Categories.Commands
{
    public class UpdateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Disabled { get; set; }
    }
}

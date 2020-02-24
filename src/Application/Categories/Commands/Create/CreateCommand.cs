using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen.Application.Categories.Commands
{
    public class CreateCommand : IRequest<int>
    {
          public string Name { get; set; }
        public bool Disabled { get; set; }
    }
}

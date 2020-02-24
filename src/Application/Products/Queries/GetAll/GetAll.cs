using AutoMapper;
using Canteen.Application.Products.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Clean_Architecture_Task.Application.Common.Interfaces;

namespace Canteen.Application.Products.Queries
{
    public class GetAll:IRequest<List<ProductLiDto>>
    {
        public class Handler : IRequestHandler<GetAll, List<ProductLiDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<ProductLiDto>> Handle(GetAll request, CancellationToken cancellationToken)
            {
                // Get All Products
                return _mapper.Map<List<ProductLiDto>>(
                    await _context.Products
                    .Where(a =>a.Deleted == false && a.Disabled==false)
                    .ToListAsync(cancellationToken));
            }
        }
    }
}

using AutoMapper;
using Canteen.Application.Categories.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Clean_Architecture_Task.Application.Common.Interfaces;

namespace Canteen.Application.Categories.Queries
{
    public class GetAll:IRequest<List<CategoryDto>>
    {
        public class Handler : IRequestHandler<GetAll, List<CategoryDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<CategoryDto>> Handle(GetAll request, CancellationToken cancellationToken)
            {
                // Get All Categories
                return _mapper.Map<List<CategoryDto>>(
                    await _context.Categories
                    .Where(a =>a.Deleted == false )
                    .ToListAsync(cancellationToken));
            }
        }
    }
}

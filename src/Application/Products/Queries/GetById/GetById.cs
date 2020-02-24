using AutoMapper;
using Canteen.Application.Products.Models;
using Clean_Architecture_Task.Application.Common.Exceptions;
using Clean_Architecture_Task.Application.Common.Interfaces;
using Clean_Architecture_Task.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Canteen.Application.Products.Queries
{
    public class GetById: IRequest<ProductDto>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetById, ProductDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ProductDto> Handle(GetById request, CancellationToken cancellationToken)
            {
                var Entity = await _context.Products
                    .Include(s=>s.Category)
                    .FirstOrDefaultAsync(a => a.Id == request.Id && a.Deleted == false, cancellationToken);
                if (Entity == null)
                    throw new NotFoundException(nameof(Product), request.Id);
                return _mapper.Map<ProductDto>(Entity);
            }
        }

    }
}

using AutoMapper;
using Canteen.Application.Products.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Clean_Architecture_Task.Application.Common.Interfaces;
using Clean_Architecture_Task.Application.Common.Exceptions;
using Clean_Architecture_Task.Domain.Entities;

namespace Canteen.Application.Products.Queries
{
    public class GetByBarCode : IRequest<ProductDto>
    {
        public string Barcode { get; set; }
        public class Handler : IRequestHandler<GetByBarCode, ProductDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ProductDto> Handle(GetByBarCode request, CancellationToken cancellationToken)
            {
                var Entity = await _context.Products
                    .Include(s=>s.Category)
                    .FirstOrDefaultAsync(a => a.BarCode == request.Barcode && a.Deleted == false, cancellationToken);
                if (Entity == null)
                    throw new NotFoundException(nameof(Product), request.Barcode);
                return _mapper.Map<ProductDto>(Entity);
            }
        }

    }
}

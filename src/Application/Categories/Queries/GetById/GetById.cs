using AutoMapper;
using Canteen.Application.Categories.Models;
using Clean_Architecture_Task.Application.Common.Exceptions;
using Clean_Architecture_Task.Application.Common.Interfaces;
using Clean_Architecture_Task.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Canteen.Application.Categories.Queries
{
    public class GetById: IRequest<CategoryDto>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetById, CategoryDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<CategoryDto> Handle(GetById request, CancellationToken cancellationToken)
            {
                var Entity = await _context.Categories
                    .FirstOrDefaultAsync(a => a.Id == request.Id && a.Deleted == false, cancellationToken);
                if (Entity == null)
                    throw new NotFoundException(nameof(Category), request.Id);
                return _mapper.Map<CategoryDto>(Entity);
            }
        }

    }
}

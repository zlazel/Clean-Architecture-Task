using Clean_Architecture_Task.Application.Common.Exceptions;
using Clean_Architecture_Task.Application.Common.Interfaces;
using Clean_Architecture_Task.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Canteen.Application.Products.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Product
                {
                    Name = request.Name.Trim(),
                    CategoryId = request.CategoryId,
                    Description = request.Description,
                    BarCode = request.BarCode,
                    SellingPrice = request.SellingPrice,
                };
                _context.Products.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }
            catch (Exception exp)
            {
                throw new AddEntityFailureException (nameof(Product), exp);
            }
        }
    }
}

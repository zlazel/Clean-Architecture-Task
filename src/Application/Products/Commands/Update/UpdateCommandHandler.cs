using Clean_Architecture_Task.Application.Common.Exceptions;
using Clean_Architecture_Task.Application.Common.Interfaces;
using Clean_Architecture_Task.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Canteen.Application.Products.Commands
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public UpdateCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
              var entity = await _context.Products.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Product), request.Id);
                }

                entity.Name = request.Name;
                entity.SellingPrice = request.SellingPrice;
                entity.CategoryId = request.CategoryId;
                entity.Description = request.Description;
                entity.Disabled = request.Disabled;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
        }
    }
}

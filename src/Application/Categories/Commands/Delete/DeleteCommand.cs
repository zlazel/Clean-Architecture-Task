using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Clean_Architecture_Task.Application.Common.Interfaces;
using Clean_Architecture_Task.Application.Common.Exceptions;
using Clean_Architecture_Task.Domain.Entities;

namespace Canteen.Application.Categories.Commands
{
    public class DeleteCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class Hanlder : IRequestHandler<DeleteCommand, int>
        {
        private readonly IApplicationDbContext _context;
        public Hanlder(IApplicationDbContext context)
        {
            _context = context;
        }
            public async Task<int> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
               var entity = await _context.Categories.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Category), request.Id);
                }

                // soft delete Category 
                entity.Deleted = true;

                // hard delete Category 
               // _context.Categories.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Clean_Architecture_Task.Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Canteen.Application.Categories.Commands
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("Category Name Can't be empty")
                .MaximumLength(120).WithMessage("Category Name Maximum Length is 120 character")
                .MinimumLength(3).WithMessage("Category Name Minimum Length is 3 character")
                .MustAsync(BeUniqueName).WithMessage("The specified Name already exists.");

            RuleFor(a => a.Disabled)
                .NotNull().WithMessage("Category Disabled Can't be null");
        }
          public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Categories
                .AllAsync(l => l.Name != name);
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Clean_Architecture_Task.Application.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Canteen.Application.Categories.Commands
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
       private readonly IApplicationDbContext _context;

        public UpdateCommandValidator(IApplicationDbContext context)
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

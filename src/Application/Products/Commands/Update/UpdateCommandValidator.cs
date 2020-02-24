using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Clean_Architecture_Task.Application.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Canteen.Application.Products.Commands
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
       private readonly IApplicationDbContext _context;

        public UpdateCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("Product Name Can't be empty")
                .MaximumLength(120).WithMessage("Product Name Maximum Length is 120 character")
                .MinimumLength(3).WithMessage("Product Name Minimum Length is 3 character")
                .MustAsync(BeUniqueName).WithMessage("The specified Name already exists.");

            RuleFor(a => a.Description)
                .MinimumLength(5).WithMessage("Description Minimum Characters is 5")
                .MaximumLength(220).WithMessage("Description Maximum Characters is 220")
                .When(s => !string.IsNullOrEmpty(s.Description));

            RuleFor(a => a.CategoryId)
                .NotNull().NotEmpty().WithMessage("Product CategoryId Can't be empty or null")
                .MustAsync(IsExistCategory).WithMessage("The specified CategoryId not exists.");
        }

        private async Task<bool> IsExistCategory(int categoryId, CancellationToken cancellationToken)
        {
               return await _context.Categories
                .FindAsync(categoryId) != null;
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AllAsync(l => l.Name != name);
        }
    }
}

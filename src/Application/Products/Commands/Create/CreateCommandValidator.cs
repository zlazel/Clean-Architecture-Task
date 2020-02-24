using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Clean_Architecture_Task.Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Canteen.Application.Products.Commands
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("Product Name Can't be empty")
                .MaximumLength(120).WithMessage("Product Name Maximum Length is 120 character")
                .MinimumLength(3).WithMessage("Product Name Minimum Length is 3 character")
                .MustAsync(BeUniqueName).WithMessage("The specified Name already exists.");

            RuleFor(a => a.BarCode)
                .NotEmpty().WithMessage("Product BarCode Can't be empty")
                .Length(10).WithMessage("Product BarCode Length is 10 character")
                .MustAsync(BeUniqueBarCode).WithMessage("The specified BarCode already exists.");

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

        private async Task<bool> BeUniqueBarCode(string barCode , CancellationToken cancellationToken)
        {
           return await _context.Products
                .AllAsync(l => l.BarCode != barCode);
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AllAsync(l => l.Name != name);
        }
    }
}

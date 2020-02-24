using FluentValidation;

namespace Canteen.Application.Products.Commands
{
    public class DeleteCommandValidator: AbstractValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(s => s.Id).GreaterThan(0)
                .WithMessage("Product Id must greater than 0");
        }
    }
}

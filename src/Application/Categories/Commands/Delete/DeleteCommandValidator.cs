using FluentValidation;

namespace Canteen.Application.Categories.Commands
{
    public class DeleteCommandValidator: AbstractValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(s => s.Id).GreaterThan(0)
                .WithMessage("Category Id must greater than 0");
        }
    }
}

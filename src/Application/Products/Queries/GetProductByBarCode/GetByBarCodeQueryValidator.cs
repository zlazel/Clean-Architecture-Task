using FluentValidation;

namespace Canteen.Application.Products.Queries
{
    public class GetByBarCodeQueryValidator : AbstractValidator<GetByBarCode>
    {
        public GetByBarCodeQueryValidator()
        {
            // For Id
            RuleFor(s => s.Barcode)
                .NotEmpty()
                .NotNull()
                .WithMessage("Barcode must not empty");
        }
    }
}

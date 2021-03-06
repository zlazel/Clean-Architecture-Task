﻿using FluentValidation;

namespace Canteen.Application.Categories.Queries
{
    public class GetByIdQueryValidator: AbstractValidator<GetById>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(s => s.Id).GreaterThan(0).WithMessage("Id must greater than 0");
        }
    }
}

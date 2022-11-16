using FluentValidation;
using RYMtool.Core.Dtos;

namespace RYMtool.Core.Validators;

public class ReviewDtoValidator:AbstractValidator<ReviewDto>
{
    public ReviewDtoValidator()
    {
        RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage("message is empty or null")
            .NotNull()
            .WithMessage("message is empty or null");
        RuleFor(x => x.Reviewer)
            .NotEmpty()
            .WithMessage("reviewer is empty or null")
            .NotNull()
            .WithMessage("reviewer is empty or null");
    }
}
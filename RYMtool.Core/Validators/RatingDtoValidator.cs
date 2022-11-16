using FluentValidation;
using RYMtool.Core.Dtos;
using RYMtool.Core.Models;

namespace RYMtool.Core.Validators;

public class RatingDtoValidator:AbstractValidator<RatingDto>
{
    public RatingDtoValidator()
    {
        RuleFor(x => x.Score)
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(5)
            .WithMessage("score must be in range 1 to 5");
    }
}
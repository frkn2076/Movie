using FluentValidation;
using Movie.API.Requests;

namespace Movie.API.Validators;
public class MovieDetailRequestValidator : AbstractValidator<MovieDetailRequest>
{
    public MovieDetailRequestValidator()
    {
        RuleFor(x => x).NotNull();
        RuleFor(p => p.Id).NotEmpty();
    }
}

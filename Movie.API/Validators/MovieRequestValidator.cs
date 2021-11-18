using FluentValidation;
using Movie.API.Requests;

namespace Movie.API.Validators;
public class MovieRequestValidator : AbstractValidator<MovieRequest>
{
    public MovieRequestValidator()
    {
        RuleFor(p => p.UserId).GreaterThan(0);
        RuleFor(p => p.Movie).SetValidator(new MovieDetailRequestValidator());
    }
}

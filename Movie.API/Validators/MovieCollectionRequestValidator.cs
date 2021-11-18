using FluentValidation;
using Movie.API.Requests;

namespace Movie.API.Validators;
public class MovieCollectionRequestValidator : AbstractValidator<MovieCollectionRequest>
{
    public MovieCollectionRequestValidator()
    {
        RuleFor(p => p.MovieNames).NotEmpty();
    }
}
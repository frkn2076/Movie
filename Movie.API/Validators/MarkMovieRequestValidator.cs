using FluentValidation;
using Movie.API.Requests;

namespace Movie.API.Validators;
public class MarkMovieRequestValidator : AbstractValidator<MarkMovieRequest>
{
    public MarkMovieRequestValidator()
    {
        RuleFor(p => p.MovieId).NotEmpty();
    }
}

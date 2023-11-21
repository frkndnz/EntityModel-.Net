using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>
    {
        public  CreateGenreCommandValidator()
        {
            RuleFor(command => command.genreModel.Name).MinimumLength(4).NotEmpty();
        }
    }
}
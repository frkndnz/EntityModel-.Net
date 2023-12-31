using System;
using FluentValidation;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator: AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
           RuleFor(command => command.Model.GenreId).GreaterThan(0);
           RuleFor(command => command.Model.PageCount).GreaterThan(0);
           RuleFor(command => command.Model.PublishDate.Date).LessThan(DateTime.Now);
           RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}
using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.model.Surname).NotEmpty().MinimumLength(4);
            RuleFor(command => command.model.DateOfBirth.Date).LessThan(DateTime.Now.Date).NotEmpty();
        }
    }
}
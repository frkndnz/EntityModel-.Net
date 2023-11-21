using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.model.DateOfBirth.Date).NotEmpty().LessThan(DateTime.Now);
            RuleFor(command => command.model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.model.Surname).NotEmpty().MinimumLength(4);


        }
    }
}
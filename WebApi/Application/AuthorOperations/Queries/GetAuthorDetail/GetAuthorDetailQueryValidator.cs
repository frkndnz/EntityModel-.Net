using FluentValidation;

namespace WebApi.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsDetailQueryValidator:AbstractValidator<GetAuthorsDetailQuery>
    {
        public GetAuthorsDetailQueryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);
        }
    }
}
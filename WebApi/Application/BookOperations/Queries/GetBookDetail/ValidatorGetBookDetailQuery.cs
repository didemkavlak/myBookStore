using FluentValidation;

namespace WebApi.Applications.BookOperations.Queries.GetBookDetail
{
    public class ValidatorGetBookDetailQuery :  AbstractValidator<GetBookDetailQuery>
    {
        public ValidatorGetBookDetailQuery() 
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}
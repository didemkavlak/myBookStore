using FluentValidation;

namespace WebApi.BookOperations.GetBookDetail
{
    public class ValidatorGetBookDetailQuery :  AbstractValidator<GetBookDetailQuery>
    {
        public ValidatorGetBookDetailQuery() 
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}
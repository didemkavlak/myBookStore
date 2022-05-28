using FluentValidation;

namespace WebApi.BookOperations.DeleteBook
{
    public class ValidatorDeleteBookCommand : AbstractValidator<DeleteBookCommand>
    {
        public ValidatorDeleteBookCommand()
        {
            RuleFor(commond => commond.BookId).GreaterThan(0);
        }

    }
}
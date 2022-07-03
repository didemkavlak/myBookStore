using FluentValidation;

namespace WebApi.Applications.BookOperations.Commands.DeleteBook
{
    public class ValidatorDeleteBookCommand : AbstractValidator<DeleteBookCommand>
    {
        public ValidatorDeleteBookCommand()
        {
            RuleFor(commond => commond.BookId).GreaterThan(0);
        }

    }
}
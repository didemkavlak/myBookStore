using FluentValidation;

namespace WebApi.Applications.BookOperations.Commands.UpdateBook
{
    public class ValidatorUpdateBookCommand :  AbstractValidator<UpdateBookCommand>
    {
        public ValidatorUpdateBookCommand()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}
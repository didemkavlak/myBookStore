using FluentValidation;

namespace WebApi.Applications.BookOperations.Commands.CreateBook
{
    public class ValidatorCreateBookCommond : AbstractValidator<CreateBookCommand>
    {
        public ValidatorCreateBookCommond()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
        }
    }
}
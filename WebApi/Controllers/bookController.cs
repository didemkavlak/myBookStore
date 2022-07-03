using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.BookOperations.Commands.CreateBook;
using WebApi.Applications.BookOperations.Commands.DeleteBook;
using WebApi.Applications.BookOperations.Commands.GetBooks;
using WebApi.Applications.BookOperations.Commands.UpdateBook;
using WebApi.Applications.BookOperations.Queries.GetBookDetail;
using WebApi.DBOperations;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("[controller]s")]
    public class bookController : ControllerBase
    {
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public bookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Get

        [HttpGet]
        public IActionResult GetBooks(){
            
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookDetailViewModel result;
            
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);

                query.BookId = id;

                ValidatorGetBookDetailQuery validator = new ValidatorGetBookDetailQuery();
                validator.ValidateAndThrow(query);

                result = query.Handle();
            
                return Ok(result);
        }

        // FromQuery
        // [HttpGet]

        // public Book Get([FromQuery] string id)
        // {
        //     var book = BookList.Where( book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        //Post

        [HttpPost]

        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);

                command.Model = newBook;

                ValidatorCreateBookCommond validator = new ValidatorCreateBookCommond();
                validator.ValidateAndThrow(command);

               
                command.Handle();
        

                return Ok();
        }

        //Put
        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel UpdatedBook)
        {
            
            UpdateBookCommand command = new UpdateBookCommand(_context);

            command.BookId = id;
            command.Model = UpdatedBook;
            ValidatorUpdateBookCommand validator = new ValidatorUpdateBookCommand();
            validator.ValidateAndThrow(command);

            command.Handle();
             
            return Ok();

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);

                command.BookId = id;
                ValidatorDeleteBookCommand validator = new ValidatorDeleteBookCommand();
                validator.ValidateAndThrow(command);

                command.Handle();

                return Ok();
        }
    }
}
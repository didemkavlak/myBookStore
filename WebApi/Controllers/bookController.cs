using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
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
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);

                query.BookId = id;

                ValidatorGetBookDetailQuery validator = new ValidatorGetBookDetailQuery();
                validator.ValidateAndThrow(query);

                result = query.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            
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

            try
            {
                command.Model = newBook;

                ValidatorCreateBookCommond validator = new ValidatorCreateBookCommond();
                validator.ValidateAndThrow(command);

               
                command.Handle();
                
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        //Put
        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel UpdatedBook)
        {
            
            UpdateBookCommand command = new UpdateBookCommand(_context);

            try
            {

            command.BookId = id;
            command.Model = UpdatedBook;
            ValidatorUpdateBookCommand validator = new ValidatorUpdateBookCommand();
            validator.ValidateAndThrow(command);

            command.Handle();
                
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }

            return Ok();

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);

            try
            {
                command.BookId = id;
                ValidatorDeleteBookCommand validator = new ValidatorDeleteBookCommand();
                validator.ValidateAndThrow(command);

                command.Handle();
                
            }
            catch (Exception ex) 
            {
                
                return BadRequest(ex.Message);
            };

                return Ok();
        }
    }
}
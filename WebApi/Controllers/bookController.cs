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
        public bookController (BookStoreDbContext context)
        {
            _context = context;
        }
        //Get

        [HttpGet]
        public IActionResult GetBooks(){
            
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);

                query.BookId = id;
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
            CreateBookCommand command = new CreateBookCommand(_context);

            try
            {
                
                command.Model = newBook;
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
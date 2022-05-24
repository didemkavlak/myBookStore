using Microsoft.AspNetCore.Mvc;
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
        public List<Book> GetBooks(){
            
            var bookList = _context.Books.OrderBy( x=> x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            return book;
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

        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = _context.Books.SingleOrDefault( x => x.Title == newBook.Title);

            if( book is not null)
                return BadRequest();
            
            _context.Books.Add(newBook);
                _context.SaveChanges();
                return Ok();
        }

        //Put
        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] Book UpdatedBook)
        {
            var book = _context.Books.SingleOrDefault( x => x.Id == id);

            if(book is null)
                return BadRequest();

            book.GenreId = UpdatedBook.GenreId != default ? UpdatedBook.GenreId : book.GenreId;
            book.PageCount = UpdatedBook.PageCount != default ? UpdatedBook.PageCount : book.PageCount;
            book.PublishDate = UpdatedBook.PublishDate != default ? UpdatedBook.PublishDate : book.PublishDate;
            book.Title = UpdatedBook.Title != default ? UpdatedBook.Title : book.Title;

                _context.SaveChanges();
                return Ok();

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault( x => x.Id == id);

            if(book is null)
                return BadRequest();

            _context.Books.Remove(book);

                _context.SaveChanges();
                return Ok();
        }
    }
}


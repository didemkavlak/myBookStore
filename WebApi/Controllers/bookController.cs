using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("[controller]s")]
    public class bookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title = "Lean Startup",
                GenreId = 1, //Personal Growth 
                PageCount = 200,
                PublishDate = new DateTime(2001,06,12),
            },

            new Book
            {
                Id= 2,
                Title = "Herland",
                GenreId = 2, //Science Fiction
                PageCount = 500,
                PublishDate = new DateTime(1999, 02 , 15),
            },

            new Book
            {
                Id= 3,
                Title = "Dune",
                GenreId = 2, //Science Fiction
                PageCount = 1500,
                PublishDate = new DateTime(1999, 02 , 15),
            }
        };

        //Get

        [HttpGet]
        public List<Book> GetBooks(){
            
            var bookList = BookList.OrderBy( x=> x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
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
            var book = BookList.SingleOrDefault( x => x.Title == newBook.Title);

            if( book is not null)
                return BadRequest();
            
            BookList.Add(newBook);
                return Ok();
        }

        //Put
        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] Book UpdatedBook)
        {
            var book = BookList.SingleOrDefault( x => x.Id == id);

            if(book is null)
                return BadRequest();

            book.GenreId = UpdatedBook.GenreId != default ? UpdatedBook.GenreId : book.GenreId;
            book.PageCount = UpdatedBook.PageCount != default ? UpdatedBook.PageCount : book.PageCount;
            book.PublishDate = UpdatedBook.PublishDate != default ? UpdatedBook.PublishDate : book.PublishDate;
            book.Title = UpdatedBook.Title != default ? UpdatedBook.Title : book.Title;

                return Ok();

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault( x => x.Id == id);

            if(book is null)
                return BadRequest();

            BookList.Remove(book);
                return Ok();
        }
    }
}


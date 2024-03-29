using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Applications.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQuery{
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetBookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();

            if(book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            GetBookDetailViewModel vm = _mapper.Map<GetBookDetailViewModel>(book);
            return vm;
        }
    }
    public class GetBookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }

    }
}
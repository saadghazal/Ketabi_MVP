using Ketabi.Core.Data;
using Ketabi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ketabi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService  _bookService;
        public BookController (IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        [Route("AllBook")]
        public List<Book> GitAllBook()
        {
            return _bookService.GitAllBook();
        }
        [HttpPost]
        [Route("CreateBook")]
        public void CreateBook(Book book)
        {
            _bookService.CreateBook(book);
        }
        [HttpPut]
        [Route("UpdateBook")]
        public void UpdateBook(Book book)
        {
            _bookService.UpdateBook(book);
        }
        [HttpDelete]
        [Route("DeleteBook")]
        public void DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
        }
        [HttpGet]
        [Route("BookById")]
        public Book GetBookById(int id)
        {
            return _bookService.GetBookById(id);
        }
        [HttpGet]
        [Route("SearchByBookName")]
        public List<Book> SearchByBookName(string bookName)
        {
            return _bookService.SearchByBookName(bookName);
        }
        [HttpGet]
        [Route("FilterByCategory")]
        public List<Book> FilterByCategory(string category)
        {
            return _bookService.FilterByCategory(category);
        }
        [HttpGet]
        [Route("NumOfPages")]
        public List<Book> FilterByNumberOfPages(int numberOfPages)
        {
            return _bookService.FilterByNumberOfPages(numberOfPages);
        }
        [HttpGet]
        [Route("Language")]
        public List<Book> FilterByLanguages(string language)
        {
            return _bookService.FilterByLanguages(language);
        }
        [HttpGet]
        [Route("Library")]
        public List<Book> SearchByLibrary(string library)
        {
            return _bookService.SearchByLibrary(library);
        }
    }
}

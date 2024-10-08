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
        private readonly IBookService _bookService;
        public BookController (IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("GetAllBook")]
        public List<Book> GetAllBook()
        {
            return _bookService.GetAllBook();
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
        [Route("GetBookById")]
        public Book GetBookById(int id)
        {
            return _bookService.GetBookById(id);
        }
        [HttpGet]
        [Route("SearchByBookName")]
        public List<Book> SearchByBookName(string name)
        {
            return _bookService.SearchByBookName(name);
        }
        [HttpGet]
        [Route("FilterByCategory")]
        public List<Book> FilterByCategory(string category)
        {
            return _bookService.FilterByCategory(category);
        }
        [HttpGet]
        [Route("FilterByNumberOfPages")]
        public List<Book> FilterByNumberOfPages(int numberOfPages)
        {
            return _bookService.FilterByNumberOfPages(numberOfPages);
        }
        [HttpGet]
        [Route("FilterByLanguages")]
        public List<Book> FilterByLanguages(string language)
        {
            return _bookService.FilterByLanguages(language);
        }
        [HttpGet]
        [Route("SearchByLibrary")]
        public List<Book> SearchByLibrary(string library)
        {
            return _bookService.SearchByLibrary(library);
        }

        [HttpPost]
        [Route("uploadImage")]
        public Book UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Book item = new Book();
            item.Image = fileName;
            return item;
        }
    }
}

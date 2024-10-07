using Ketabi.Core.Data;
using Ketabi.Core.Repositories;
using Ketabi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Infra.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book> GetAllBook()
        {
            return _bookRepository.GetAllBook();
        }
        public void CreateBook(Book book)
        {
            _bookRepository.CreateBook(book);
        }
        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }
        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }
        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }
        public List<Book> SearchByBookName(string name)
        {
            return _bookRepository.SearchByBookName(name);
        }
        public List<Book> FilterByCategory(string category)
        {
            return _bookRepository.FilterByCategory(category);
        }
        public List<Book> FilterByNumberOfPages(int numberOfPages)
        {
            return _bookRepository.FilterByNumberOfPages(numberOfPages);
        }
        public List<Book> FilterByLanguages(string language)
        {
            return _bookRepository.FilterByLanguages(language);
        }
        public List<Book> SearchByLibrary(string library)
        {
            return _bookRepository.SearchByLibrary(library);
        }
    }
}

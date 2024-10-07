using Ketabi.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.Services
{
    public interface IBookService 
    {
        List<Book> GetAllBook();
        void CreateBook(Book book);
        public void UpdateBook(Book book);
        void DeleteBook(int id);
        Book GetBookById(int id);
        List<Book> SearchByBookName(string name);
        List<Book> FilterByCategory(string category);
        List<Book> FilterByNumberOfPages(int numberOfPages);
        List<Book> FilterByLanguages(string language);
        List<Book> SearchByLibrary(string library);
    }
}

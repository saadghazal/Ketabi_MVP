using Ketabi.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.Repositories
{
    public interface IBookRepository
    {
        List<Book> GitAllBook();
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        Book GetBookById(int id);
        List<Book> SearchByBookName (string bookName);
        List<Book> FilterByCategory (string category);
        List<Book> FilterByNumberOfPages (int numberOfPages);
        List<Book> FilterByLanguages (string language);
        List<Book> SearchByLibrary (string library);
    }
}

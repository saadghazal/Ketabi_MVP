using Dapper;
using Ketabi.Core.Common;
using Ketabi.Core.Data;
using Ketabi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbContext _dbContext;
        public BookRepository (IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Book> GitAllBook()
        {
            var queryStatement = "Book_Package.GetAllBook";

            IEnumerable<Book> allBook = _dbContext.Connection.Query<Book>(queryStatement, commandType: CommandType.StoredProcedure);

            return allBook.ToList();
        }
        public void CreateBook(Book book)
        {
            var creationStatement = "Book_Package.CreateBook";
            var result = _dbContext.Connection.Execute
                (creationStatement, PassCreateBookParameters(book), commandType: CommandType.StoredProcedure);
        }
        DynamicParameters PassCreateBookParameters(Book book)
        {
            var p = new DynamicParameters();
            p.Add("P_BookName", book.Bookname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_languages", book.Languages, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_numberOfPages", book.Numberofpages, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_releaseDate", book.Releasedate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("P_descriptions", book.Descriptions, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_image", book.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_quantity", book.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_price", book.Priceperday, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("P_authorId", book.Authorid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_categoryId", book.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_Libraryid", book.Libraryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
        public void UpdateBook(Book book)
        {
            var ubdateStatement = "Book_Package.UpdateBook";
            var result = _dbContext.Connection.Execute
                (ubdateStatement, PassUpdateBookParameters(book), commandType: CommandType.StoredProcedure);
        }
        DynamicParameters PassUpdateBookParameters (Book book)
        {
            var p = new DynamicParameters();
            p.Add("P_BookId", book.Bookid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_BookName", book.Bookname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_languages", book.Languages, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_numberOfPages", book.Numberofpages, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_releaseDate", book.Releasedate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("P_descriptions", book.Descriptions, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_image", book.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_quantity", book.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_price", book.Priceperday, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("P_authorId", book.Authorid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_categoryId", book.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_Libraryid", book.Libraryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
        public void DeleteBook(int id)
        {
            var deletionStatement = "Book_Package.DeleteBook";
            var result = _dbContext.Connection.Execute
                (deletionStatement, PassBookId(id), commandType: CommandType.StoredProcedure);
        }
    
        public Book GetBookById(int id)
        {
            var GetBookByIdStatement = "Book_Package.GetBookById";
            var result = _dbContext.Connection.Query<Book>(GetBookByIdStatement, PassBookId(id), commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        DynamicParameters PassBookId(int id)
        {
            var p = new DynamicParameters();
            p.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
     
        public List<Book> SearchByBookName(string bookName)
        {
            var searchStatement = "Book_Package.SearchByBookName";
            IEnumerable<Book> allBook = _dbContext.Connection.Query<Book>(searchStatement, PassBookName(bookName), commandType: CommandType.StoredProcedure);
            return allBook.ToList();
        }
        DynamicParameters PassBookName(string bookName)
        {
            var p = new DynamicParameters();
            p.Add("P_BookName", bookName, dbType: DbType.String, direction: ParameterDirection.Input);
            return p;
        }
        public List<Book> FilterByCategory(string category)
        {
            var CategoryStatement = "Book_Package.FilterByCategory";
            IEnumerable<Book> allBook = _dbContext.Connection.Query<Book>(CategoryStatement, PassCategory(category), commandType: CommandType.StoredProcedure);
            return allBook.ToList();
        }
        DynamicParameters PassCategory(string category)
        {
            var p = new DynamicParameters();
            p.Add("Cat_Name", category, dbType: DbType.String, direction: ParameterDirection.Input);
            return p;
        }
        public List<Book> FilterByNumberOfPages(int numberOfPages)
        {
            var NumberOfPagesStatement = "Book_Package.FilterByNumberOfPages";
            IEnumerable<Book> allBook = _dbContext.Connection.Query<Book>(NumberOfPagesStatement, PassNumOfPages(numberOfPages), commandType: CommandType.StoredProcedure);
            return allBook.ToList();

        }
        DynamicParameters PassNumOfPages (int num)
        {
            var p = new DynamicParameters();
            p.Add("P_numberOfPages", num , dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
        public List<Book> FilterByLanguages(string language)
        {
            var LanguagesStatement = "Book_Package.FilterByLanguages";
            IEnumerable<Book> allBook = _dbContext.Connection.Query<Book>(LanguagesStatement, PassLanguages(language), commandType: CommandType.StoredProcedure);
            return allBook.ToList();
        }
        DynamicParameters PassLanguages (string language)
        {
            var p = new DynamicParameters();
            p.Add("P_languages", language, dbType: DbType.String, direction: ParameterDirection.Input);
            return p;
        }
        public List<Book> SearchByLibrary(string library)
        {
            var LibraryStatement = "Book_Package.SearchByLibrary";
            IEnumerable<Book> allBook = _dbContext.Connection.Query<Book>(LibraryStatement, PassLibrary(library), commandType: CommandType.StoredProcedure);
            return allBook.ToList();
        }
        DynamicParameters PassLibrary (string library)
        {
            var p = new DynamicParameters();
            p.Add("Library_Name", library, dbType: DbType.String, direction: ParameterDirection.Input);
            return p;
        }
    }
}

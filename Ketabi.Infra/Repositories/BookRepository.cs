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
        public BookRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Book> GetAllBook()
        {
            IEnumerable<Book> result = _dbContext.Connection.Query<Book>
                ("Book_Package.GetAllBook", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void CreateBook(Book book)
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

            var result = _dbContext.Connection.Execute
                ("Book_Package.CreateBook", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateBook(Book book)
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

            var result = _dbContext.Connection.Execute
                ("Book_Package.UpdateBook", p, commandType: CommandType.StoredProcedure);
        }
        public void DeleteBook(int id)
        {
            var p = new DynamicParameters();
            p.Add("P_BookId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute
             ("Book_Package.DeleteBook", p, commandType: CommandType.StoredProcedure);
        }
        public Book GetBookById(int id)
        {
            var p = new DynamicParameters();
            p.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Book> result = _dbContext.Connection.Query<Book>
                ("Book_Package.GetBookById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public List<Book> SearchByBookName(string name)
        {
            var p = new DynamicParameters();
            p.Add("P_BookName", name, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Book> result = _dbContext.Connection.Query<Book>
             ("Book_Package.SearchByBookName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Book> FilterByCategory(string category)
        {
            var p = new DynamicParameters();
            p.Add("Cat_Name", category, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Book> result = _dbContext.Connection.Query<Book>
             ("Book_Package.FilterByCategory", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Book> FilterByNumberOfPages(int numberOfPages)
        {
            var p = new DynamicParameters();
            p.Add("P_numberOfPages", numberOfPages, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Book> result = _dbContext.Connection.Query<Book>
             ("Book_Package.FilterByNumberOfPages", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Book> FilterByLanguages(string language)
        {
            var p = new DynamicParameters();
            p.Add("P_languages", language, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Book> result = _dbContext.Connection.Query<Book>
            ("Book_Package.FilterByLanguages", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Book> SearchByLibrary(string library)
        {
            var p = new DynamicParameters();
            p.Add("Library_Name", library, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Book> result = _dbContext.Connection.Query<Book>
            ("Book_Package.SearchByLibrary", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}

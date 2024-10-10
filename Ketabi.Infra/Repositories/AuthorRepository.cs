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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbContext _dbContext;

        public AuthorRepository(IDbContext dbContext) { 
            _dbContext = dbContext;
        }

        public void CreateAuthor(Author newAuthor)
        {
            var createStatement = "Author_Package.AddAuthor";
            _dbContext.Connection.Execute(createStatement, PassCreateAuthorParams(newAuthor), commandType: CommandType.StoredProcedure);
        }

        DynamicParameters PassCreateAuthorParams(Author newAuthor)
        {
            var parameters = new DynamicParameters();
            parameters.Add("A_Name", newAuthor.Authorname, DbType.String, ParameterDirection.Input);
            parameters.Add("bio_content", newAuthor.Bio, DbType.String, ParameterDirection.Input);
            parameters.Add("Img", newAuthor.Image, DbType.String, ParameterDirection.Input);
            return parameters;

        }

        public void DeleteAuthor(int authorId)
        {
            var deleteStatement = "Author_Package.RemoveAuthor";
            _dbContext.Connection.Execute(deleteStatement,PassAuthorId(authorId), commandType: CommandType.StoredProcedure);
        }
        DynamicParameters PassAuthorId(int authorId) {
            var parameters = new DynamicParameters();
            parameters.Add("Id",authorId, DbType.String, ParameterDirection.Input);
            return parameters;
        }
        public List<Author> GetAllAuthors()
        {
            var queryStatement = "Author_Package.GetAllAuthors";
            var allAuthors =_dbContext.Connection.Query<Author>(queryStatement,commandType:CommandType.StoredProcedure);
            return allAuthors.ToList();
        }

        public Author GetAuthorById(int authorId)
        {
            var queryStatement = "Author_Package.GetAuthorById";

            var requestedAuthor = _dbContext.Connection
                .Query<Author>(queryStatement, PassAuthorId(authorId), commandType: CommandType.StoredProcedure);
            return requestedAuthor.Single();
        }

         

        public List<Author> SearchAuthorByName(string authorName)
        {
            var queryStatement = "Author_Package.SearchAuthorByName";

            var searchedAuthors = _dbContext.Connection.Query<Author>(queryStatement,PassAuthorName(authorName),commandType:CommandType.StoredProcedure);

            return searchedAuthors.ToList();
        }
        DynamicParameters PassAuthorName(string authorName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", authorName, DbType.String, ParameterDirection.Input);
            return parameters;
        }

            public void UpdateAuthor(Author newAuthor)
        {
            var updateStatement = "Autho_Package.UpdateAuthor";
            _dbContext.Connection.Execute(updateStatement, PassUpdateAuthorParams(newAuthor),commandType: CommandType.StoredProcedure);
        }

        DynamicParameters PassUpdateAuthorParams(Author newAuthor)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", newAuthor.Authorid, DbType.String, ParameterDirection.Input);
            parameters.Add("A_Name", newAuthor.Authorname, DbType.String, ParameterDirection.Input);
            parameters.Add("bio_content", newAuthor.Bio, DbType.String, ParameterDirection.Input);
            parameters.Add("Img", newAuthor.Image, DbType.String, ParameterDirection.Input);
            return parameters;

        }
    }
}

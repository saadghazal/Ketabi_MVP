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
    public class FavoriteBookRepository : IFavoriteBookRepository
    {
        private readonly IDbContext _dbContext;

        public FavoriteBookRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddToFavorites(int bookId, int userId)
        {
            var addStatement = "FavoriteBookPackage.AddToUserFavorites";
            _dbContext.Connection
                .Execute(addStatement,PassAddToOrRemoveFromFavoritesParams(bookId,userId),
                commandType:CommandType.StoredProcedure);

        }

        public List<Favoritebook> GetUserFavoriteBooks(int userId)
        {
            var queryStatement = "FavoriteBookPackage.GetAllUserFavoriteBooks";

            var userFavoriteBooks = _dbContext.Connection
                .Query<Favoritebook>(queryStatement
                ,PassUserId(userId),commandType:CommandType.StoredProcedure);
            return userFavoriteBooks.ToList();
        }

        public void RemoveFromFavorites(int bookId, int userId)
        {
            var deleteStatement = "FavoriteBookPackage.DeleteFavoriteBook";
            _dbContext.Connection
                .Execute(deleteStatement, PassAddToOrRemoveFromFavoritesParams(bookId, userId),
                commandType: CommandType.StoredProcedure);
        }

        DynamicParameters PassAddToOrRemoveFromFavoritesParams(int bookId, int userId) {
            var parameters = new DynamicParameters();
            parameters.Add("book_id", bookId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("user_id", userId, DbType.Int32, ParameterDirection.Input);
            return parameters;
        }

        DynamicParameters PassUserId( int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("user_id", userId, DbType.Int32, ParameterDirection.Input);
            return parameters;
        }
    }
}

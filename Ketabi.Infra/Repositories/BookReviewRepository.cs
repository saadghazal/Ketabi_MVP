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
    public class BookReviewRepository : IBookReviewRepository
    {
        private readonly IDbContext _dbContext;
        public BookReviewRepository (IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Bookreview> GetAllReview()
        {
            var queryStatement = "BookReview_Package.GetAllReview";
            var allReview = _dbContext.Connection.Query<Bookreview>(queryStatement, commandType: CommandType.StoredProcedure);
            return allReview.ToList();
        }
        public void AddReview(Bookreview bookreview)
        {
            var creationStatement = "BookReview_Package.AddReview";
            var result = _dbContext.Connection.Execute
                (creationStatement, PassParametersToAdd(bookreview), commandType: CommandType.StoredProcedure);
        }
        DynamicParameters PassParametersToAdd (Bookreview bookreview)
        {
            var p = new DynamicParameters ();
            p.Add("P_Rating", bookreview.Rating, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_Comments", bookreview.Comments, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_UserId", bookreview.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_BookId", bookreview.Bookid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
        public void UpdateReview(Bookreview bookreview)
        {
            var UpdateStatement = "BookReview_Package.UpdateReview";
            var result = _dbContext.Connection.Execute
                (UpdateStatement, ParametersToUpdate(bookreview), commandType: CommandType.StoredProcedure);
        }
        DynamicParameters ParametersToUpdate (Bookreview bookreview)
        {
            var p = new DynamicParameters ();
            p.Add("P_Id", bookreview.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_Rating", bookreview.Rating, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_Comments", bookreview.Comments, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_UserId", bookreview.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_BookId", bookreview.Bookid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
        public void DeleteReview(int id)
        {
            var deletionStatement = "BookReview_Package.DeleteReview";
            var result = _dbContext.Connection.Execute
                (deletionStatement, PassId(id), commandType: CommandType.StoredProcedure);
        }
        public Bookreview GetReviewById(int id)
        {

            var GetByIdStatement = "BookReview_Package.GetReviewById";
            var result = _dbContext.Connection.Query<Bookreview>(GetByIdStatement, PassId(id), commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        DynamicParameters PassId (int id)
        {
            var p = new DynamicParameters();
            p.Add("P_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
        public List<Bookreview> GetReviewByrating(string rating)
        {
            var queryStatement = "BookReview_Package.GetReviewByrating";
            var allReview = _dbContext.Connection.Query<Bookreview>(queryStatement, PassDataByRating(rating), commandType: CommandType.StoredProcedure);
            return allReview.ToList();
        }
        DynamicParameters PassDataByRating (string rating)
        {
            var p = new DynamicParameters();
            p.Add("P_Rating", rating, dbType: DbType.String, direction: ParameterDirection.Input);
            return p;
        }
    }
}

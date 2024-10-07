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
    public class BookReivewRepository: IBookReivewRepository
    {
        private readonly IDbContext _dbContext;
        public BookReivewRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Bookreview> GetAllReview()
        {
            IEnumerable<Bookreview> result = _dbContext.Connection.Query<Bookreview>
                ("BookReview_Package.GetAllReview", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void AddReview(Bookreview review)
        {
            var p = new DynamicParameters();
            p.Add("P_Rating", review.Rating, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_Comments", review.Comments, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_UserId", review.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_BookId", review.Bookid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute
               ("BookReview_Package.AddReview", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateReview(Bookreview review)
        {
            var p = new DynamicParameters();
            p.Add("P_Id", review.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_Rating", review.Rating, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_Comments", review.Comments, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_UserId", review.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_BookId", review.Bookid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute
               ("BookReview_Package.UpdateReview", p, commandType: CommandType.StoredProcedure);
        }
        public void DeleteReview(int id)
        {
            var p = new DynamicParameters();
            p.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute
               ("BookReview_Package.DeleteReview", p, commandType: CommandType.StoredProcedure);
        }
        public Bookreview GetReviewById(int id)
        {
            var p = new DynamicParameters();
            p.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Bookreview> result = _dbContext.Connection.Query<Bookreview>
              ("BookReview_Package.GetReviewById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public List<Bookreview> GetReviewByrating(int rating)
        {
            var p = new DynamicParameters();
            p.Add("P_Rating", rating, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Bookreview> result = _dbContext.Connection.Query<Bookreview>
              ("BookReview_Package.GetReviewByrating", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}

using Dapper;
using Ketabi.Core.Common;
using Ketabi.Core.Data;
using Ketabi.Core.DTO;
using Ketabi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Infra.Repositories
{
    public class BorrowedBookRepository : IBorrowedBookRepository
    {
        private readonly IDbContext _dbContext;
        public BorrowedBookRepository (IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Borrowedbook> GetAllBorrowed()
        {
            var queryStatement = "BorrowedBook_Package.GetAllBorrowed";
            var allBorrowed = _dbContext.Connection.Query<Borrowedbook>(queryStatement, commandType: CommandType.StoredProcedure);
            return allBorrowed.ToList();
        }
        public void CreateNewBorrow(Borrowedbook borrowedbook)
        {
            var creationStatement = "BorrowedBook_Package.CreateNewBorrow";
            var result = _dbContext.Connection.Execute
                (creationStatement, PaasParametersToCreateBorrowed(borrowedbook), commandType: CommandType.StoredProcedure);
        }
        DynamicParameters PaasParametersToCreateBorrowed (Borrowedbook borrowedbook)
        {
            var p = new DynamicParameters ();
            p.Add("P_borrowingDate", borrowedbook.Borrowingdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("P_dueDate", borrowedbook.Duedate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("P_amount", borrowedbook.Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("P_BookId", borrowedbook.Bookid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_UserId", borrowedbook.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_Libraryid", borrowedbook.Libraryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
        public void ChangeStatusToReturned(int id)
        {
            var statusStatement = "BorrowedBook_Package.ChangeStatusToReturned";
            var result = _dbContext.Connection.Execute
                (statusStatement, PassBorrowedId(id), commandType: CommandType.StoredProcedure);
        }
        public void ChangeStatusToRequireFees(int id)
        {
            var statusStatement = "BorrowedBook_Package.ChangeStatusToRequireFees";
            var result = _dbContext.Connection.Execute
                (statusStatement, PassBorrowedId(id), commandType: CommandType.StoredProcedure);
        }
        public void DeleteBorrowed(int id)
        {
            var deletionStatement = "BorrowedBook_Package.DeleteBorrowed";
            var result = _dbContext.Connection.Execute
                (deletionStatement, PassBorrowedId(id), commandType: CommandType.StoredProcedure);
        }
        public Borrowedbook GetBorrowById(int id)
        {
            var GetByIdStatement = "BorrowedBook_Package.GetBorrowById";
            var result = _dbContext.Connection.Query<Borrowedbook>(GetByIdStatement, PassBorrowedId(id), commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        DynamicParameters PassBorrowedId(int id)
        {
            var p = new DynamicParameters();
            p.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
        public List<HistoryOfBorrowing> GethistoryOfborrowingByuserId(int userid)
        {
            var GetByUserIdStatement = "BorrowedBook_Package.GethistoryOfborrowingByuserId";
            var result = _dbContext.Connection.Query<HistoryOfBorrowing>(GetByUserIdStatement, PassUserId(userid), commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        DynamicParameters PassUserId(int userid)
        {
            var p = new DynamicParameters();
            p.Add("P_UserId", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
    }
}

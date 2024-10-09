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
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly IDbContext _dbContext;
        public CreditCardRepository (IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Creditcard> GetAllCredit()
        {
            var queryStatement = "CreditCard_Package.GetAllCredit";
            var allCredit = _dbContext.Connection.Query<Creditcard>(queryStatement, commandType: CommandType.StoredProcedure);
            return allCredit.ToList();
        }
        public void AddNewCredit(Creditcard creditcard)
        {
            var creationStatement = "CreditCard_Package.AddNewCredit";
            var result = _dbContext.Connection.Execute
                (creationStatement, PassToCreateCredit(creditcard), commandType: CommandType.StoredProcedure);
        }
        DynamicParameters PassToCreateCredit (Creditcard creditcard)
        {
            var p = new DynamicParameters();
            p.Add("P_HolderName", creditcard.Holdername, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_CreditNumber", creditcard.Creditnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_ExpiryDate", creditcard.Expirydate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("P_CVV", creditcard.Cvv, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_Balance", creditcard.Balance, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("P_userId", creditcard.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
        public void UpdateCredit(Creditcard creditcard)
        {
            var UpdateStatement = "CreditCard_Package.UpdateCredit";
            var result = _dbContext.Connection.Execute
                (UpdateStatement, PassToUpdateCredit(creditcard), commandType: CommandType.StoredProcedure);
        }
        DynamicParameters PassToUpdateCredit (Creditcard creditcard)
        {
            var p = new DynamicParameters();
            p.Add("P_Id", creditcard.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_HolderName", creditcard.Holdername, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_CreditNumber", creditcard.Creditnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_ExpiryDate", creditcard.Expirydate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("P_CVV", creditcard.Cvv, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("P_Balance", creditcard.Balance, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("P_userId", creditcard.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
        public void DeleteCredit(int id)
        {
            var deletionStatement = "CreditCard_Package.DeleteCredit";
            var result = _dbContext.Connection.Execute
                (deletionStatement, PassId(id), commandType: CommandType.StoredProcedure);
        }
        public Creditcard GetCreditById(int id)
        {
            var GetByIdStatement = "CreditCard_Package.GetCreditById";
            var result = _dbContext.Connection.Query<Creditcard>(GetByIdStatement, PassId(id), commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        DynamicParameters PassId (int id)
        {
            var p = new DynamicParameters();
            p.Add("P_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return p;
        }
        public Creditcard GetCreditByUserId(int userId)
        {
            var GetByUserIdStatement = "CreditCard_Package.GetCreditById";
            var result = _dbContext.Connection.Query<Creditcard>(GetByUserIdStatement, PassUserId(userId), commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        DynamicParameters PassUserId (int userId)
        {
            var p = new DynamicParameters();
            p.Add("P_userId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return p;
        }
    }
}

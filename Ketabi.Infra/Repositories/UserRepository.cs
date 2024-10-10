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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ketabi.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext) {
            _dbContext = dbContext;
        }
        public async void RegisterUser(UserDTO newUser)
        {
            
           
            int userId = await CreateUser(newUser);

           
            StoreLoginCredentials(newUser, userId);
        }

        async Task<int> CreateUser(UserDTO newUser) {
            var createUserParams = PassCreateUserParams(newUser);
            var createStatement = "UserPackage.CreateUser";

            await _dbContext.Connection.ExecuteAsync(createStatement, createUserParams, commandType: CommandType.StoredProcedure);


            return createUserParams.Get<int>("p_UserId");
        }

        async void StoreLoginCredentials(UserDTO newUser,int userId) {
            var storeLoginCredentialsParams = PassLoginCredentialsParams(newUser, userId);

            var storeLoginStatement = "LoginPackage.StoreUserLoginCredentials";

            await _dbContext.Connection.ExecuteAsync(storeLoginStatement, storeLoginCredentialsParams, commandType: CommandType.StoredProcedure);
        }

        DynamicParameters PassCreateUserParams(UserDTO newUser) {
            var parameters = new DynamicParameters();

            // Add input parameters for the procedure
            parameters.Add("p_Image", newUser.UserData.Image, DbType.String);
            parameters.Add("p_FirstName", newUser.UserData.Firstname, DbType.String);
            parameters.Add("p_LastName", newUser.UserData.Lastname, DbType.String);
            parameters.Add("p_Email", newUser.UserData.Email, DbType.String);
            parameters.Add("p_PhoneNumber", newUser.UserData.Phonenumber, DbType.String);
            parameters.Add("p_Address", newUser.UserData.Address, DbType.String);

            parameters.Add("p_UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            return parameters;
        }

        DynamicParameters PassLoginCredentialsParams(UserDTO newUser,int newUserId) {
            var parameters = new DynamicParameters();

            // Add input parameters for the procedure
            parameters.Add("p_Username", newUser.LoginData.Username, DbType.String);   // p_Username parameter
            parameters.Add("p_Password", newUser.LoginData.Password, DbType.String);   // p_Password parameter
            parameters.Add("p_userId", newUserId, DbType.Int32);        // p_userId parameter (Assuming login.userid%TYPE is int)
            parameters.Add("p_roleId", 1, DbType.Int32);

            return parameters;
        }
    }
}

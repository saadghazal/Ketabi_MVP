using Dapper;
using Ketabi.Core.Common;
using Ketabi.Core.Data;
using Ketabi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Infra.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly IDbContext _dbContext;

        public LibraryRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;
        }
        public void CreateLibrary(Library newLibrary)
        {

            var passedParameteres = PassCreateLibraryParameters(newLibrary);
            var creationStatement = "LibraryPackage.CreateLibrary";
            _dbContext.Connection.Execute(creationStatement, passedParameteres, commandType: CommandType.StoredProcedure);

        }

        DynamicParameters PassCreateLibraryParameters(Library newLibrary)
        {
            var parameters = new DynamicParameters();
            parameters.Add("libraryName", newLibrary.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("libraryEmail", newLibrary.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("phone", newLibrary.Phonenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("img", newLibrary.Image, DbType.String, ParameterDirection.Input);
            parameters.Add("lng", newLibrary.Longitude, DbType.String, ParameterDirection.Input);
            parameters.Add("lat", newLibrary.Latitude, DbType.String, ParameterDirection.Input);
            return parameters;
        }

        public void DeleteLibrary(int libraryId)
        {


            var deletionStatement = "LibraryPackage.DeleteLibrary";

            _dbContext.Connection.Execute(deletionStatement, PassLibraryId(libraryId), commandType: CommandType.StoredProcedure);
        }

        DynamicParameters PassLibraryId(int libraryId)
        {
            var parameteres = new DynamicParameters();
            parameteres.Add("id", libraryId, DbType.Int32, ParameterDirection.Input);

            return parameteres;
        }

        public List<Library> GetAllLibraries()
        {
            var queryStatement = "LibraryPackage.GetAllLibraries";

            var allLibraries = _dbContext.Connection.Query<Library>(queryStatement, commandType: CommandType.StoredProcedure);

            return allLibraries.ToList();

        }

        public Library GetLibraryById(int id)
        {
            var queryStatement = "LibraryPackage.GetLibraryById";

            var requestedLibrary = _dbContext.Connection.
                Query<Library>(queryStatement, PassLibraryId(id), commandType: CommandType.StoredProcedure).SingleOrDefault();

            return requestedLibrary;

        }

        public Library GetLibraryByLocation(string lat, string lng)
        {


            var queryStatemen = "LibraryPackage.SearchLibraryByLocation";

            var requestedLibrary = _dbContext.Connection.
                Query<Library>(queryStatement, PassLibraryLocation(lat, lng), commandType: CommandType.StoredProcedure).SingleOrDefault();

            return requestedLibrary;
        }
        DynamicParameters PassLibraryLocation(string lat, string lng)
        {
            var parameters = new DynamicParameters();
            parameters.Add("lng", lng, DbType.String, ParameterDirection.Input);
            parameters.Add("lat", lat, DbType.String, ParameterDirection.Input);

            return parameters;
        }
        public Library GetLibraryByName(string name)
        {
            var queryStatement = "LibraryPackage.SearchLibraryByName";

            var requestedLibrary = _dbContext.Connection
                .Query<Library>(queryStatement, PassLibraryName(name), commandType: CommandType.StoredProcedure);

            return requestedLibrary.SingleOrDefault();
        }

        DynamicParameters PassLibraryName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("libraryName", name, DbType.String, ParameterDirection.Input);
            return parameters;
        }

        public void UpdateLibrary(Library updatedLibrary)
        {
            var updateStatement = "LibraryPackage.UpdateLibrary";

            _dbContext.Connection.
                Execute(updateStatement, PassUpdateLibraryParameters(updatedLibrary), commandType: CommandType.StoredProcedure);
        }
        DynamicParameters PassUpdateLibraryParameters(Library updatedLibrary)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", updatedLibrary.Libraryid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("libraryName", updatedLibrary.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("libraryEmail", updatedLibrary.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("phone", updatedLibrary.Phonenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("img", updatedLibrary.Image, DbType.String, ParameterDirection.Input);
            parameters.Add("lng", updatedLibrary.Longitude, DbType.String, ParameterDirection.Input);
            parameters.Add("lat", updatedLibrary.Latitude, DbType.String, ParameterDirection.Input);
            return parameters;
        }

    }

}

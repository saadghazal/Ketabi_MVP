using Dapper;
using Ketabi.Core.Common;
using Ketabi.Core.Data;
using Ketabi.Core.Repositories;
using Ketabi.Infra.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dbContext;

        public CategoryRepository(IDbContext dbContext) {
            _dbContext = dbContext;
        }
        public void CreateCategory(Category newCategory)
        {
            var createStatemnt = "CategoryPackage.CreateCategory";
            _dbContext.Connection.Execute(createStatemnt, PassCreateCategoryParams(newCategory), commandType: CommandType.StoredProcedure);

        }

        DynamicParameters PassCreateCategoryParams(Category newCategory) {
            var parameters = new DynamicParameters();
            parameters.Add("p_CategoryName", newCategory.Categoryname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_IconPath", newCategory.Iconpath, DbType.String, ParameterDirection.Input);
            return parameters;
        }

        public void DeleteCategory(int categoryId)
        {
            var deleteStatment = "CategoryPackage.DeleteCategory";
            _dbContext.Connection.Execute(deleteStatment, PassCategoryId(categoryId), commandType: CommandType.StoredProcedure);
        }

        DynamicParameters PassCategoryId(int categoryId) {

            var parameters = new DynamicParameters();
            parameters.Add("p_CategoryId",categoryId,DbType.Int32,ParameterDirection.Input);
            return parameters;

        }

        public List<Category> GetAllCategories()
        {
            var queryStatment = "CategoryPackage.GetAllCategories";
            
            var allCategories = _dbContext.Connection.Query<Category>(queryStatment,commandType: CommandType.StoredProcedure); 
            return allCategories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            var queryStatment = "CategoryPackage.GetCategoryById";
            var requestedCategory =  _dbContext.Connection.Query<Category>(queryStatment, PassCategoryId(categoryId), commandType: CommandType.StoredProcedure);
            return requestedCategory.SingleOrDefault();
        }

        public void UpdateCategory(Category newCategory)
        {
            var updateStatemnt = "CategoryPackage.UpdateCategory";
            _dbContext.Connection.Execute(updateStatemnt, PassUpdateCategoryParams(newCategory), commandType: CommandType.StoredProcedure);

        }
        DynamicParameters PassUpdateCategoryParams(Category newCategory)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CategoryId", newCategory.Categoryid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_CategoryName", newCategory.Categoryname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_IconPath", newCategory.Iconpath, DbType.String, ParameterDirection.Input);
            return parameters;
        }
    }
}

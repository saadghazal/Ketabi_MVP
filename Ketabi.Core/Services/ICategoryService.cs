using Ketabi.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Core.Services
{
    public interface ICategoryService
    {
        void CreateCategory(Category newCategory);
        void UpdateCategory(Category newCategory);

        void DeleteCategory(int categoryId);

        List<Category> GetAllCategories();

        Category GetCategoryById(int categoryId);
    }
}

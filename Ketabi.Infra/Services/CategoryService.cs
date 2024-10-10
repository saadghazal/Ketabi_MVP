using Ketabi.Core.Data;
using Ketabi.Core.Repositories;
using Ketabi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabi.Infra.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) { 
            _categoryRepository = categoryRepository;
        }
        public void CreateCategory(Category newCategory)
        {
           _categoryRepository.CreateCategory(newCategory);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }

        public List<Category> GetAllCategories()
        {
           return _categoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }

        public void UpdateCategory(Category newCategory)
        {
           _categoryRepository.UpdateCategory(newCategory);
        }
    }
}

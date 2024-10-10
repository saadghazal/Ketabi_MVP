using Ketabi.Core.Data;
using Ketabi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ketabi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly Helpers _helpers;

        public CategoryController(ICategoryService categoryService,Helpers helpers)
        {
            _categoryService = categoryService;
            _helpers = helpers;
        }

        [HttpGet]
        [Route("categories")]
        public List<Category> GetCategories()
        {
            return _categoryService.GetAllCategories();
        }

        [HttpGet]
        [Route("{id}")]
        public Category GetCategoryById(int id) 
        {
            return _categoryService.GetCategoryById(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteCategory(int id) { 
            _categoryService.DeleteCategory(id);
        }

        [HttpPost]
        [Route("add-category")]
        [Consumes("multipart/form-data")]
        public IActionResult CreateCategory([FromForm]Category newCategory)
        {
            if (isCreateCategoryBadRequest(newCategory)) {
                return BadRequest(newCategory);
            }
            newCategory.Iconpath = _helpers.GetFileNameAfterUploading(Request, "CategoriesIcons");

            _categoryService.CreateCategory(newCategory);
            return Ok("Category created successfully");
        }


        
        bool isCreateCategoryBadRequest(Category newCategory) => newCategory.Categoryname == null || newCategory.iconFile == null;

        [HttpPut]
        [Route("update-category")]
        [Consumes("multipart/form-data")]
        public IActionResult UpdateCategory(Category newCategory)
        {
            if (newCategory.iconFile != null) {
                newCategory.Iconpath = _helpers.GetFileNameAfterUploading(Request, "CategoriesIcons");
            }

            _categoryService.UpdateCategory(newCategory);

            return Ok("Category updated successfully");
        }
    }
}

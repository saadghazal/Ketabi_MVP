using Ketabi.Core.Data;
using Ketabi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ketabi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly Helpers _helpers;

        public AuthorController(IAuthorService authorService, Helpers helpers)
        {
            _authorService = authorService;
            _helpers = helpers;
        }

        [HttpGet]
        [Route("authors")]
        public List<Author> GetAllAuthors() {
           return _authorService.GetAllAuthors();
        }

        [HttpGet]
        [Route("{id}")]
        public Author GetAuthorById(int id) { 
            return _authorService.GetAuthorById(id);   
        }

        [HttpGet]
        [Route("search/{name}")]
        public List<Author> SearchAuthorByName(string name) { 
            return _authorService.SearchAuthorByName(name);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            _authorService.DeleteAuthor(id);
            return Ok("Author deleted successfully");
        }

        [HttpPost]
        [Route("add-author")]
        [Consumes("multipart/form-data")]
        public IActionResult CreateAuthor([FromForm] Author author) {
            if (isCreateAuthorBadRequest(author)) {
                return BadRequest();
            }
            author.Image = _helpers.GetFileNameAfterUploading(Request, "AuthorsImages");

            _authorService.CreateAuthor(author);

            return Ok("Author created successfully");
        }

        bool isCreateAuthorBadRequest(Author author) => author.Authorname == null || author.authorImageFile == null || author.Bio == null;

        [HttpPut]
        [Route("update-author")]
        [Consumes("multipart/form-data")]
        public IActionResult UpdateAuthor([FromForm] Author author) {
            if (author.authorImageFile != null)
            {
                author.Image = _helpers.GetFileNameAfterUploading(Request, "AuthorsImages");
            }

            _authorService.UpdateAuthor(author);

            return Ok("Author updated successfully");

        }

        
    }
}

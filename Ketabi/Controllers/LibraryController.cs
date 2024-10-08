using Ketabi.Core.Data;
using Ketabi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ketabi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        [Route("libraries")]
        public List<Library> GetAllLibraries()
        {
            return _libraryService.GetAllLibraries();
        }

        [HttpGet]
        [Route("{id}")]
        public Library GetLibraryById(int id)
        {
            return _libraryService.GetLibraryById(id);
        }


        [HttpGet]
        [Route("search-by-name")]
        public Library GetLibraryByName([FromQuery] string name)
        {
            return _libraryService.GetLibraryByName(name);
        }

        [HttpGet]
        [Route("search-by-location")]
        public Library GetLibraryByLocation([FromQuery] string lat, [FromQuery] string lng)
        {
            return _libraryService.GetLibraryByLocation(lat, lng);
        }

        [HttpPost]
        [Route("add-library")]
        public void CreateLibrary(Library library)
        {
            _libraryService.CreateLibrary(library);
        }


        [HttpPut]
        [Route("update-library")]
        public void UpdateLibrary(Library library)
        {
            _libraryService.UpdateLibrary(library);
        }

        [HttpDelete]
        [Route("delete-library/{id}")]
        public void DeleteLibrary(int id)
        {
            _libraryService.DeleteLibrary(id);
        }
    }
}

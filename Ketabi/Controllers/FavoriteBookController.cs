using Ketabi.Core.Data;
using Ketabi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ketabi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteBookController : ControllerBase
    {
        private readonly IFavoriteBookService _favoriteBookService;

        public FavoriteBookController(IFavoriteBookService favoriteBookService)
        {
            _favoriteBookService = favoriteBookService;
        }

        [HttpGet]
        [Route("user-favorites/{userId}")]
        public List<Favoritebook> GetUserFavorites(int userId) {
            return _favoriteBookService.GetUserFavoriteBooks(userId);
        }


        [HttpPost]
        [Route("add-to-favorites")]
        public IActionResult AddToFavorites([FromQuery] int bookId, [FromQuery] int userId) {
            _favoriteBookService.AddToFavorites(bookId, userId);
            return Ok("Added to favorites successfully");
        }

        [HttpDelete]
        [Route("remove-from-favorites")]
        public IActionResult RemoveFromFavorites([FromQuery] int favoriteBookId, [FromQuery] int userId)
        {
            _favoriteBookService.RemoveFromFavorites(favoriteBookId, userId);
            return Ok("Removed from favorites successfully");
        }
    }
}

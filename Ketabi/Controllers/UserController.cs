using Ketabi.Core.DTO;
using Ketabi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ketabi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Helpers _helpers;

        public UserController(IUserService userService, Helpers helpers)
        {
            _userService = userService;
            _helpers = helpers;
        }


        [HttpPost]
        [Route("register")]
        [Consumes("multipart/form-data")]
        public IActionResult RegisterUser([FromForm] UserDTO newUser) {
            newUser.UserData.Image = _helpers.GetFileNameAfterUploading(Request, "UsersImages");

            _userService.RegisterUser(newUser);

            return Ok("User created successfully");

        }
    }
}

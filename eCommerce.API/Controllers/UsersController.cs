using eCommerce.Core.DTOs;
using eCommerce.Core.Entities.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /api/Users/{userID}
        [HttpGet("{userID}")]
        public async Task<IActionResult> GetUserByUserID(Guid userID) //102
        {
            if (userID == Guid.Empty)
            {
                return BadRequest("Invalid User ID");
            }

            UserDTO? userDto = await _userService.GetUserByUserId(userID);
            if (userDto == null)
            {
                return NotFound(userDto);
            }
            else
            {
                return Ok(userDto);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserServices _userServices;

        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet] 
        public async Task<List<User>> FindAllUsersController() 
        { 
            return await _userServices.FindAllUsersServices();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userServices.CreateUserServices(user);
            return CreatedAtAction(nameof(FindAllUsersController), new {id = user.Id}); 
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            await _userServices.UpdateUserServices(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userServices.DeleteUserServices(id);
            return NoContent();
        }
    }
}

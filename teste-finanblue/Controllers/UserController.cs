using Microsoft.AspNetCore.Mvc;
using teste_finanblue.Models;
using teste_finanblue.Repositories.Interfaces;

namespace teste_finanblue.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("/users")]
        public async Task<ActionResult<List<User>>> ReturnAllUsers()
        {
            List<User> users = await _userRepository.ReturnAllUsers();
            return Ok(users);
        }

        [HttpPost("/users")]
        public async Task<ActionResult<User>> AddUser([FromBody] User userModel)
        {
            User user = await _userRepository.AddUser(userModel);
            return Ok(user);
        }
    }
}

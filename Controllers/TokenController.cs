using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using teste_finanblue.Models;
using teste_finanblue.Repositories.Interfaces;
using teste_finanblue.Services.Interfaces;

namespace teste_finanblue.Controllers
{
    public class TokenController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public TokenController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Auth([FromBody] User userModel)
        {
            User user = await _userRepository.ReturnUserByLogin(userModel.email, userModel.password);

            if (user == null)
            {
                throw new Exception("Usuário ou senha inválidos");
            }

            var token = _tokenService.GenerateToken(user);

            user.password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}

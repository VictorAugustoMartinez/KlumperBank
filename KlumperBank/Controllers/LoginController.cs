using KlumperBank.Repositories.Contracts;
using KlumperBank.Services;
using KlumperBank.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace KlumperBank.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }


        [HttpPost]
        [Route("v1/login")]
        public async Task<ActionResult<dynamic>> Login(
        [FromBody] LoginViewModel model)
        {

            var user = _userRepository.GetUserForLogin(model.Email, model.Password, model);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "*****";
            return new
            {
                user,
                token
            };
        }
    }
}

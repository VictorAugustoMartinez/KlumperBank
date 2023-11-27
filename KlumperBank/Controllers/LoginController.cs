using KlumperBank.Repositories.Contracts;
using KlumperBank.Services;
using KlumperBank.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace KlumperBank.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IGetUserRepository _getUserRepository;
        public LoginController(IGetUserRepository getUserRepository)
        {
            _getUserRepository = getUserRepository;
        }


            [HttpPost]
        [Route("v1/login")]
        public async Task<ActionResult<dynamic>> Login(
                [FromBody] LoginViewModel model)
        {

            var user = _getUserRepository.GetUserForLogin(model.Email, model.Password, model);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            //user.Password = "*****";
            return new
            {
                user = user,
                token = token
            };
        }
    }
}

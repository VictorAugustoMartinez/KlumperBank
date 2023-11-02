using KlumperBank.Models;
using KlumperBank.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KlumperBank.Controllers
{
    [ApiController]
    [Route("")]
    public class UserController : ControllerBase
    {
        private readonly IGetUserRepository _getUserRepository;
        private readonly IPostUserRepository _postUserRepository;
        private readonly IUpdateUserRepository _UpdateUserRepository;
        public UserController(IGetUserRepository getUserRepository, IPostUserRepository postUserRepository, IUpdateUserRepository updateUserRepository)
        {
            _getUserRepository = getUserRepository;
            _postUserRepository = postUserRepository;
            _UpdateUserRepository = updateUserRepository;
        }


        [HttpPost("v1/user")]
         public async Task<IActionResult> Create(
             [FromBody] User model
             ) 
         {
            var user = await _postUserRepository.CreateUserAsync(model);
            return Ok(user);
         }

        [HttpGet("v1/user")]
        public async Task<IActionResult>GetAll()
        {
                var users = await _getUserRepository.GetUsers();
                return Ok(users);
        }


        [HttpGet("v1/user/{id:int}")]
        public async Task<IActionResult> GetById(
            [FromRoute]int id
        )
        {
           var user =  await _getUserRepository.GetUserById(id);
            return Ok(user);
        }

        
        [HttpPut("v1/user/{id:int}")]
        public async Task<IActionResult>Update(
            [FromRoute] int id,
            [FromBody] User model
            )
        {
            var user = await _UpdateUserRepository.UpdateUser(id, model);
            return Ok(user);
        }
    }
}

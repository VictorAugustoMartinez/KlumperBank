using KlumperBank.Models;
using KlumperBank.Repositories;
using KlumperBank.Repositories.Contracts;
using KlumperBank.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KlumperBank.Controllers
{
    [ApiController]
    [Route("")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;

        }

        [HttpPost("v1/user")]
        //[Authorize(Roles = "adm")]
        public async Task<IActionResult> Create(
            [FromBody] User model
            )
        {
            var user = await _userRepository.CreateUserAsync(model);
            return Ok(user);
        }

        [HttpGet("v1/user")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }


        [HttpGet("v1/user/{id:int}")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult> GetById(
            [FromRoute] int id
        )
        {
            var user = await _userRepository.GetUserById(id);
            return Ok(user);
        }


        [HttpPut("v1/user/{id:int}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateViewModel model
            )
        {
            var user = await _userRepository.UpdateUser(id, model);
            return Ok(user);
        }

        [HttpPut("v1/user/transaction/{senderId:int}/{receiverId:int}/{amount:int}")]
        [Authorize]
        public async Task<IActionResult> Transaction(
            [FromRoute] int senderId,
            [FromRoute] int receiverId,
            [FromRoute] int amount
            )
        {
            var user = await _userRepository.TransactionUser(senderId, receiverId, amount);
            return Ok(user);
        }
    }
}

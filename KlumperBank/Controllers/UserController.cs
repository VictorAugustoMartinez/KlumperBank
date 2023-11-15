using KlumperBank.Models;
using KlumperBank.Repositories.Contracts;
using KlumperBank.Services;
using KlumperBank.ViewModel;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ITransactionUserRepository _transactionUserRepository;
        public UserController(IGetUserRepository getUserRepository, IPostUserRepository postUserRepository, IUpdateUserRepository updateUserRepository, ITransactionUserRepository transactionUserRepository)
        {
            _getUserRepository = getUserRepository;
            _postUserRepository = postUserRepository;
            _UpdateUserRepository = updateUserRepository;
            _transactionUserRepository = transactionUserRepository;

        }

        [HttpPost("v1/user")]
        //[Authorize(Roles = "adm")]
         public async Task<IActionResult> Create(
             [FromBody] User model
             ) 
         {
            var user = await _postUserRepository.CreateUserAsync(model);
            return Ok(user);
         }

        [HttpGet("v1/user")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult>GetAll()
        {
                var users = await _getUserRepository.GetUsers();
                return Ok(users);
        }


        [HttpGet("v1/user/{id:int}")]
        [Authorize(Roles = "adm")]
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
            [FromBody] UpdateViewModel model
            )
        {
            var user = await _UpdateUserRepository.UpdateUser(id, model);
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
            var user = await _transactionUserRepository.TransactionUser(senderId, receiverId, amount);
            return Ok(user);
        }
    }
}

using Api.Modules.UserModule.Domain.Repository;
using Api.Modules.UserModule.Domain.Repository.Dtos;
using Microsoft.AspNetCore.Mvc;



namespace Api.Modules.UserModule.HTTP
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
      
               await _userRepository.Create(user);

            return Created("created","User Created");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUser(UpdateUserDto user)
        {
            var updatedUser = await _userRepository.Update(user);
            return Ok(updatedUser);
        }
        [HttpGet ("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            var users = await _userRepository.FindById(id);
            return Ok(users);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.FindAll();
            return Ok(users);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var deletedUser = await _userRepository.Delete(Id);
            return Ok(deletedUser);
        }

    }
}
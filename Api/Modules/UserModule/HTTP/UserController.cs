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
            var newUser = await _userRepository.Create(user);

            return Created("created", newUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto user)
        {
            var updatedUser = await _userRepository.Update(user);
            return Ok(updatedUser);
        }
        [HttpGet]
        public async Task<IActionResult> FindById(Guid Id)
        {
            var users = await _userRepository.FindById(Id);
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
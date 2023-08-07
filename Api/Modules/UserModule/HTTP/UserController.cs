using Api.Modules.UserModule.Domain.Repository;
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
        public IActionResult CreateUser()
        {


            return Created("created", "Created");
        }





    }
}
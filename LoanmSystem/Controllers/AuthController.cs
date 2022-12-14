using LoanmSystem.Model;
using LoanmSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanmSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }

        [HttpPost]

        public IActionResult Login(Login user)
        {
            var res = _userRepository.Authenticate(user);
            if (res == null)
            {
                return NotFound("username or password is incorrect");
            }
            return Ok(_tokenHandler.CreateToken(res));
        }
    }
}

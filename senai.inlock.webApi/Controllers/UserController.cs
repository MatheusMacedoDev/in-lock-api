using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.DataTransfer;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Login(UserTransfer user)
        {
            try
            {
                UserDomain findedUser = _userRepository.login(user);

                if (findedUser == null)
                {
                    return NotFound("Os dados não correspondem a nenhum usuário.");
                }

                return Ok(findedUser);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}

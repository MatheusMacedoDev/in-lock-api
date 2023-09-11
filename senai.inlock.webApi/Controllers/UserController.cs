using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.DataTransfer;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

        /// <summary>
        /// É o endpoint no qual o usuário se loga e é gerado um token
        /// </summary>
        /// <returns>Resposta ao usuário</returns>
        [HttpPost]
        public IActionResult Login(UserTransfer user)
        {
            try
            {
                // Finding for user

                UserDomain findedUser = _userRepository.login(user);

                if (findedUser == null)
                {
                    return NotFound("Os dados não correspondem a nenhum usuário.");
                }

                // Creating token

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, findedUser.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, findedUser.Email),
                    new Claim(ClaimTypes.Role, findedUser.IdUserType.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev"));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(issuer: "senai.inlock.webApi", audience: "senai.inlock.webApi", claims: claims, expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials);

                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}

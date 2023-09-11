using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class GameController : ControllerBase
    {
        private IGameRepository gameRepository;

        public GameController()
        {
            gameRepository = new GameRepository();
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            try
            {
                List<GameDomain> games = gameRepository.FindAll();

                return Ok(games);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Create(GameDomain game)
        {
            try
            {
                gameRepository.Create(game);

                return StatusCode(201);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}

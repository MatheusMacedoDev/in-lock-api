﻿using Microsoft.AspNetCore.Authorization;
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
    public class StudioController : ControllerBase
    {
        private IStudioRepository _studioRepository;

        public StudioController()
        {
            _studioRepository = new StudioRepository();
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                List<StudioDomain> studios = _studioRepository.ListAll();

                return Ok(studios);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Create(StudioDomain studio)
        {
            try
            {
                _studioRepository.Create(studio);

                return StatusCode(201);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}

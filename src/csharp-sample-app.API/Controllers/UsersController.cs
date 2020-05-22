using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using csharp_sample_app.Application.DTO;
using csharp_sample_app.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace csharp_sample_app.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public Task<IEnumerable<GetUserListDTO>> Get()
        {
            return _userService.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDTO>> Get(Guid id)
        {
            _logger.LogInformation($"Request for user with id: {id}");

            var book = await _userService.GetAsync(id);

            if (book == null)
            {
                _logger.LogInformation($"Request for user [NotFound] with id: {id}");
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostUserDTO user)
        {
            await _userService.AddAsync(user);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PutUserDTO user)
        {
            await _userService.UpdateAsync(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation($"Delete with id: {id}");

            await _userService.DeleteAsync(id);

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using WebAPI.Business.Core;
using WebAPI.Business.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Users Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly ILogger _logger;
        public UsersController(IUserService userService, ILogger logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Generate the JwT Token for user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            _logger.Information($"User {model.Username} authenticating...");
            var response = _userService.Authenticate(model);
            
            if (response == null)
            {
                _logger.Warning($"User {model.Username} or password {model.Password} is incorrect.");
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            _logger.Information($"User {model.Username} authenticated!");
            return Ok(response);
        }
    }
}

using Creed.Podcast.Domain.Exceptions;
using Creed.Podcast.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Creed.Podcast.WebApi.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> logger;
        private readonly ISecurityService securityService;

        public AuthenticationController(ILogger<AuthenticationController> logger, ISecurityService securityService)
        {
            this.logger = logger;
            this.securityService = securityService;
        }

        /// <summary>
        /// Authenticate the user
        /// </summary>
        /// <param name="username">username/email, for testing use admin</param>
        /// <param name="password">password, for testing use admin</param>
        /// <returns>Returns an object with token and expiration if credentials are valid otherwise badrequest.</returns>
        /// <exception cref="DomainValidationException"></exception>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Login([Required] string username, [Required] string password)
        {
            var accessToken = securityService.AuthenticateUser(username, password);

            if (accessToken == null)
                throw new DomainValidationException("Invalid username or password.");

            return Ok(accessToken);
        }
    }
}

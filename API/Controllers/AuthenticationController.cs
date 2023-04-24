using API.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _serviceUser;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IUserService serviceUser, ILogger<AuthenticationController> logger)
        {
            _serviceUser = serviceUser;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var token = _serviceUser.Authenticate(model.Cpf, model.Password);
            if(string.IsNullOrWhiteSpace(token))
                return Unauthorized();

            return Ok(token);
        }
    }
}

using Domain.Commands.User;
using Domain.Handlers;
using Domain.Queries;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Commands;

namespace API.Controllers
{
    public class UserController : Controller
    {
         private readonly UserHandler _handler;
        private readonly IUserAccountService _serviceUserAccount;
        private readonly ILogger<UserController> _logger;

        public UserController(UserHandler handler, IUserAccountService serviceUserAccount, ILogger<UserController> logger)
        {
            _handler = handler;
            _serviceUserAccount = serviceUserAccount;
            _logger = logger;
        }

        [HttpPost]
        [Route("v1/user")]
        public ICommandResult Post(RegisterUserCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/user")]
        public ICommandResult Put(EditUserCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpGet, Authorize]
        [Route("v1/user/getaccountbycpf")]
        public IActionResult GetAccountByCPF(string cpf)
        {
            if(string.IsNullOrWhiteSpace(cpf))
                return BadRequest();

            return Ok(_serviceUserAccount.GetAccountByCPF(cpf));

        }

        [HttpPut]
        [Route("v1/user/blocked")]
        public ICommandResult BlockedId(EditUserCommand user)
        {
            return _handler.Handle(user);
        }
    }
}

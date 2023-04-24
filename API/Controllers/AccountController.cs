using Domain.Commands.Account;
using Domain.Handlers;
using Domain.Queries;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Commands;

namespace API.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService _serviceAccount;
        private readonly IUserService _serviceUser;
        private readonly IUserAccountService _serviceUserAccount;

        private readonly AccountHandler _handler;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService serviceAccount, IUserService serviceUser,
            IUserAccountService serviceUserAccount, AccountHandler handler, ILogger<AccountController> logger)
        {
            _serviceAccount = serviceAccount;
            _serviceUser = serviceUser;
            _serviceUserAccount = serviceUserAccount;
            _handler = handler;
            _logger = logger;
        }


        [HttpGet]
        [Route("v1/account/id")]
        public QueryAccount GetById(Guid idAccount)
        {
            return _serviceAccount.GetAccountId(idAccount);
        }

        [HttpPut]
        [Route("v1/account/blocked")]
        public ICommandResult BlockedId(EditAccountCommand account)
        {
            return _handler.Handle(account);
        }

    }
}

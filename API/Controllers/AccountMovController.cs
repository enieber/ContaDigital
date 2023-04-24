using Domain.Commands.AccountMov;
using Domain.Handlers;
using Domain.Queries;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Commands;

namespace API.Controllers
{
    [Authorize]
    public class AccountMovController : Controller
    {
        private readonly IAccountMovService _serviceAccountMov;

        private readonly AccountMovHandler _handler;
        private readonly ILogger<AccountController> _logger;

        public AccountMovController(IAccountMovService serviceAccountMov, AccountMovHandler handler, ILogger<AccountController> logger)
        {
            _serviceAccountMov = serviceAccountMov;
            _handler = handler;
            _logger = logger;
        }

        [HttpGet]
        [Route("v1/accountMov/id")]
        public QueryAccountMov GetById(Guid idAccountMov)
        {
            return _serviceAccountMov.GetByAccountMovId(idAccountMov);
        }

        [HttpGet]
        [Route("v1/accountMov/accountid")]
        public IEnumerable<QueryAccountMov> GetByAccountMovId(Guid idAccount, DateTime? dateBegin, DateTime? dateEnd, int pagina, int quantidade)
        {
            return _serviceAccountMov.GetByAccountId(idAccount, dateBegin, dateEnd, pagina, quantidade);
        }

        [HttpPost]
        [Route("v1/accountMov")]
        public ICommandResult Post(RegisterAccountMovCommand accountMov)
        {
            return _handler.Handle(accountMov);
        }
    }
}

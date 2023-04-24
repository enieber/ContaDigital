using Domain.Commands.User;
using Domain.Handlers;
using Domain.Queries;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Commands;

namespace API.Controllers
{
    public class TypeTransactionController : Controller
    {
        private readonly ITypeTransactionService _service;
        private readonly ILogger<UserController> _logger;

        public TypeTransactionController(ITypeTransactionService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("v1/typeTransaction")]
        public IEnumerable<QueryTypeTransaction> Get()
        {
            return _service.GetTypeTransaction();
        }
    }
}

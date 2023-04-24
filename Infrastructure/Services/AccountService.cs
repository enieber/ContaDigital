using Domain.Queries;
using Domain.Repositories;
using Domain.Services;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }
        public QueryAccount GetAccountId(Guid idAccount)
        {
            return _repository.GetAccountId(idAccount);
        }
    }
}

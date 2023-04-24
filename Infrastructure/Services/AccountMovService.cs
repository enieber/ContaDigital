using Domain.Queries;
using Domain.Repositories;
using Domain.Services;

namespace Infrastructure.Services
{
    public class AccountMovService : IAccountMovService
    {
        private readonly IAccountMovRepository _repository;
        private readonly ITypeTransactionService _service;

        public AccountMovService(IAccountMovRepository repository, ITypeTransactionService service)
        {
            _repository = repository;
            _service = service;
        }

        public double GetBalanceMov(Guid idAccount)
        {
            var movCredit = _repository.GetBalanceMov(idAccount, true);
            var movDebit = _repository.GetBalanceMov(idAccount, false);

            double balance = movCredit - movDebit;
            return balance;
        }

        public IEnumerable<QueryAccountMov> GetByAccountId(Guid idAccount, DateTime? dateBegin, DateTime? dateEnd, int page, int quantityPage)
        {
            return _repository.GetByAccountId(idAccount, dateBegin, dateEnd, page, quantityPage);
        }

        public QueryAccountMov GetByAccountMovId(Guid idAccountMov)
        {
            return _repository.GetByAccountMovId(idAccountMov);
        }

        public bool HasBalance(Guid idAccount)
        {
            var balance = GetBalanceMov(idAccount);
            return balance > 0;
        }
    }
}

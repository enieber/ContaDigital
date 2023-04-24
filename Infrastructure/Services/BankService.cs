using Domain.Queries;
using Domain.Repositories;
using Domain.Services;

namespace Infrastructure.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _repository;

        public BankService(IBankRepository repository)
        {
            _repository = repository;
        }

        public QueryBank GetBank()
        {
            return _repository.GetBank();
        }
    }
}

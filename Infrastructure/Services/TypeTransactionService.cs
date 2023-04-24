using Domain.Queries;
using Domain.Repositories;
using Domain.Services;

namespace Infrastructure.Services
{
    public class TypeTransactionService : ITypeTransactionService
    {
        private readonly ITypeTransactionRepository _repository;

        public TypeTransactionService(ITypeTransactionRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<QueryTypeTransaction> GetTypeTransaction()
        {
            return _repository.GetTypeTransaction();    
        }
    }
}

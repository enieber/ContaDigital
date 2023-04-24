using Domain.Queries;

namespace Domain.Services
{
    public interface ITypeTransactionService
    {
        IEnumerable<QueryTypeTransaction> GetTypeTransaction();
    }
}

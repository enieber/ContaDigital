using Domain.Queries;

namespace Domain.Repositories
{
    public interface ITypeTransactionRepository
    {
        IEnumerable<QueryTypeTransaction> GetTypeTransaction();

    }
}

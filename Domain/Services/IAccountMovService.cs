using Domain.Queries;

namespace Domain.Services
{
    public interface IAccountMovService
    {
        IEnumerable<QueryAccountMov> GetByAccountId(Guid idAccount, DateTime? dateBegin, DateTime? dateEnd, int page, int quantityPage);

        QueryAccountMov GetByAccountMovId(Guid idAccountMov);

        double GetBalanceMov(Guid idAccount);
        bool HasBalance(Guid idAccount);
    }
}

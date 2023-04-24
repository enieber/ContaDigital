using Domain.Commands.AccountMov;
using Domain.Entities;
using Domain.Queries;

namespace Domain.Repositories
{
    public interface IAccountMovRepository
    {
        IEnumerable<QueryAccountMov> GetByAccountId(Guid idAccount, DateTime? dateBegin, DateTime? dateEnd, int page, int quantityPage);
        QueryAccountMov GetByAccountMovId(Guid idAccountMov);
        bool RegisterAccountMov(AccountMov command);
        double GetBalanceMov(Guid idAccount, bool credit);
    }
}

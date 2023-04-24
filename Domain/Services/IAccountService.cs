using Domain.Queries;

namespace Domain.Services
{
    public interface IAccountService
    {
        QueryAccount GetAccountId(Guid idAccount);

    }
}

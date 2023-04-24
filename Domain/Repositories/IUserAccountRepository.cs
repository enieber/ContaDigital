using Domain.Commands.User;
using Domain.Commands.UserAccount;
using Domain.Entities;
using Domain.Queries;

namespace Domain.Repositories
{
    public interface IUserAccountRepository
    {
        QueryUserAccount GetUserAccountId(Guid idUser);
        bool RegisterUserAccount(UserAccount userAccount);
        bool EditUserAccount(UserAccount userAccount);
        QueryUserAccount GetAccountByCPF(string cpf);
        void UpdateLastAccess(QueryUserAccount queryUserAccount);
    }
}

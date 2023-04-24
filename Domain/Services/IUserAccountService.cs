using Domain.Queries;

namespace Domain.Services
{
    public interface IUserAccountService
    {
        QueryUserAccount GetUserAccountId(Guid idUser);
        QueryUserAccount GetAccountByCPF(string cpf);
    }
}

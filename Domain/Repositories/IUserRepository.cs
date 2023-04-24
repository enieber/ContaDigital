using Domain.Commands.User;
using Domain.Entities;
using Domain.Queries;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        QueryUser GetUserId(Guid idUser);

        QueryUserAccountAuth GetUserByCpf(string cpf);
        bool RegisterUser(User user);
        bool EditUser(User user);
    }
}

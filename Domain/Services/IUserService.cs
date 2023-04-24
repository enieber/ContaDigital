using Domain.Queries;

namespace Domain.Services
{
    public interface IUserService
    {
        QueryUser GetUserId(Guid idUser);
        string Authenticate(string cpf, string password);
    }
}

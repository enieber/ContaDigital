using Domain.Queries;
using Domain.Repositories;
using Domain.Services;

namespace Infrastructure.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _repository;

        public UserAccountService(IUserAccountRepository repository)
        {
            _repository = repository;
        }

        public QueryUserAccount GetAccountByCPF(string cpf)
        {
            return _repository.GetAccountByCPF(cpf);
        }

        public QueryUserAccount GetUserAccountId(Guid idUser)
        {
            return _repository.GetUserAccountId(idUser);    
        }
    }
}

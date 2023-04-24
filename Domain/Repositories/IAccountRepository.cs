using Domain.Commands.Account;
using Domain.Entities;
using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAccountRepository
    {
        QueryAccount GetAccountId(Guid idAccount);
        QueryAccount GetAccountByUserId(Guid idUser);
        bool RegisterAccount(Account account);
        bool EditAccount(Account account);
        bool UpdateBalance(QueryAccount account);
    }
}

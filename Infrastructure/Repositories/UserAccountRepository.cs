using Domain.Commands.UserAccount;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Infrastructure.DataBase.MySql;

namespace Infrastructure.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly MySQLDapper _command;

        public UserAccountRepository(MySQLDapper command)
        {
            _command = command;
        }

        public QueryUserAccount GetUserAccountId(Guid idUser)
        {
            var sql = $"SELECT * FROM UserAccount where iduser = '{idUser}'";

            return _command.QueryFirst<QueryUserAccount>(sql);
        }

        public QueryUserAccount GetAccountByCPF(string cpf)
        {
            var sql = $"SELECT " +
                      $"a.idaccount, u.name, b.idbank, b.age, a.number " +
                      $"FROM " +
                      $"UserAccount ua left join User u on u.iduser = ua.iduser " +
                      $"left join account a on a.idaccount = ua.idaccount " +
                      $"left join bank b on b.idbank = a.idbank " +
                      $"where u.cpf = '{cpf}'";

            return _command.QueryFirstOrDefault<QueryUserAccount>(sql);
        }

        public bool RegisterUserAccount(UserAccount userAccount)
        {
            try
            {
                userAccount.IdUserAccount = Guid.NewGuid();
                userAccount.LastAccess = DateTime.Now;

                var sql = $"insert into UserAccount(iduseraccount, iduser, idaccount, password) " +
                    $"values('{userAccount.IdUserAccount}','{userAccount.IdUser}','{userAccount.IdAccount}', '{userAccount.Password}')";

                var ret = _command.ExecuteAsync(sql, userAccount);
                if (ret.Exception != null)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditUserAccount(UserAccount userAccount)
        {
            try
            {
                var sql = $"update UserAccount set password =  '{userAccount.Password}', lastpassword = '{userAccount.LastPassword}'," +
                    $"lastaccess = '{userAccount.LastAccess}' where iduseraccount = '{userAccount.IdUserAccount}'";

                var ret = _command.ExecuteAsync(sql, userAccount);
                if (ret.Exception != null)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            };
        }

        public void UpdateLastAccess(QueryUserAccount queryUserAccount)
        {
            var sql = $"update UserAccount set  lastpassword = '{queryUserAccount.LastPassword}' where iduseraccount = '{queryUserAccount.IdUserAccount}'";
            _command.ExecuteAsync(sql, queryUserAccount);
        }
    }
}

using Domain.Commands.Account;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Infrastructure.DataBase.MySql;
using Shared.Util;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MySQLDapper _command;

        public AccountRepository(MySQLDapper command)
        {
            _command = command;
        }
        public QueryAccount GetAccountId(Guid idAccount)
        {
            var sql = $"SELECT * FROM Account where idaccount = '{idAccount}' and status = true";

            return _command.QueryFirstOrDefault<QueryAccount>(sql);
        }

        public QueryAccount GetAccountByUserId(Guid idUser)
        {
            var sql = $"SELECT * FROM Account where iduser = '{idUser}'";

            return _command.QueryFirstOrDefault<QueryAccount>(sql);
        }

        public bool RegisterAccount(Account account)
        {
            try
            {
                account.DateCreate = DateTime.Now;

                var sql = $"insert into Account(idaccount, idbank, number, balance, datecreate) " +
                    $"values('{account.IdAccount}', '{account.IdBank}', '{account.Number}', '{account.Balance}', '{account.DateCreate.ToString("yyyy/MM/dd HH:mm:ss")}')";

                var ret = _command.ExecuteAsync(sql, account);
                if (ret.Exception != null)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditAccount(Account account)
        {
            try
            {
                var _balance = Util.DoubleSetValue(account.Balance.ToString());

                var sql = $"update Account set balance =  '{_balance}', lastblocked = '{account.LastBlocked}'," +
                    $"status = '{account.Status}', blocked = '{account.Blocked}' where idaccount = '{account.IdAccount}'";

                var ret = _command.ExecuteAsync(sql, account);
                if (ret.Exception != null)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            };
        }

        public bool UpdateBalance(QueryAccount account)
        {
            try
            {
                var _balance = Util.DoubleSetValue(account.Balance.ToString());

                var sql = $"update Account set balance =  '{_balance}' where idaccount = '{account.IdAccount}'";

                var ret = _command.ExecuteAsync(sql, account);
                if (ret.Exception != null)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            };
        }
    }
}

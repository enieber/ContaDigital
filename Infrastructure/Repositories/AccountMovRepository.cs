using Domain.Commands.AccountMov;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Infrastructure.DataBase.MySql;
using Shared.Util;

namespace Infrastructure.Repositories
{
    public class AccountMovRepository : IAccountMovRepository
    {
        private readonly MySQLDapper _command;

        public AccountMovRepository(MySQLDapper command)
        {
            _command = command;
        }

        public double GetBalanceMov(Guid idAccount, bool credit)
        {
            var sql = $"select coalesce(sum(value),0) as balance from " +
                      $"accountmov m " +
                      $"inner join typetransaction t on t.idtypetransaction = m.idtypetransaction" +
                      $" where idaccount = '{idAccount}' and t.credit = {credit}";

            return _command.QueryFirstOrDefault<double>(sql);
        }

        public IEnumerable<QueryAccountMov> GetByAccountId(Guid idAccount, DateTime? dateBegin, DateTime? dateEnd, int page, int quantityPage)
        {
            if (dateBegin == null) dateBegin = DateTime.Now.AddDays(-30);
            if (dateEnd == null)  dateEnd = DateTime.Now;

            if (page == 0) page = 1;
            if (quantityPage == 0) quantityPage = 10;

            var sql = $"SELECT ac.*, t.credit, t.description as desctypetransaction FROM AccountMov ac " +
                      $" left join typetransaction t on t.idtypetransaction = ac.idtypetransaction " +
                      $" Where idaccount = '{idAccount}' " +
                      $"and (datecreate BETWEEN '{dateBegin.Value.ToString("yyyyMMdd")}' AND '{dateEnd.Value.ToString("yyyyMMdd")}')";

            sql += $" order by datecreate desc LIMIT {(page - 1) * quantityPage},{quantityPage}";

            return _command.QueryAsync<QueryAccountMov>(sql).Result;
        }

        public QueryAccountMov GetByAccountMovId(Guid idAccountMov)
        {
            var sql = $"SELECT ac.*, t.credit, t.description as desctypetransaction FROM AccountMov ac " +
                     $" left join typetransaction t on t.idtypetransaction = ac.idtypetransaction " +
                     $" where idaccountmov = '{idAccountMov}'";

            return _command.QueryFirstOrDefault<QueryAccountMov>(sql);
        }

        public bool RegisterAccountMov(AccountMov accountMov)
        {
            try
            {

                var _value = Util.DoubleSetValue(accountMov.Value.ToString());

                var sql = $"insert into AccountMov(idaccountmov, idaccount, ";

                if (accountMov.IdAccountDestination != null)
                    sql += $"idaccountdestination, ";

                sql += $"idtypetransaction, value, datecreate) values('{accountMov.IdAccountMov}', '{accountMov.IdAccount}',";

                if (accountMov.IdAccountDestination != null)
                    sql += $"'{accountMov.IdAccountDestination.Value}',";

                sql += $" '{accountMov.IdTypeTransaction}', {_value}, '{accountMov.DateCreate.ToString("yyyy/MM/dd HH:mm:ss")}')";

                var ret = _command.ExecuteAsync(sql, accountMov);

                if (ret.Exception != null)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

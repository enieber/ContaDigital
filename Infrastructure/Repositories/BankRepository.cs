using Domain.Queries;
using Domain.Repositories;
using Infrastructure.DataBase.MySql;

namespace Infrastructure.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly MySQLDapper _command;

        public BankRepository(MySQLDapper command)
        {
            _command = command;
        }

        public QueryBank GetBank()
        {
            var sql = $"SELECT * FROM Bank";

            return _command.QueryFirst<QueryBank>(sql);
        }
    }
}

using Domain.Queries;
using Domain.Repositories;
using Infrastructure.DataBase.MySql;

namespace Infrastructure.Repositories
{
    public class TypeTransactionRepository : ITypeTransactionRepository
    {
        private readonly MySQLDapper _command;

        public TypeTransactionRepository(MySQLDapper command)
        {
            _command = command;
        }

        public IEnumerable<QueryTypeTransaction> GetTypeTransaction()
        {
            var sql = $"SELECT * FROM TypeTransaction";

            return _command.QueryAsync<QueryTypeTransaction>(sql).Result;
        }
    }
}

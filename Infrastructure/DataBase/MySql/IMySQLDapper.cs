using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.DataBase.MySql
{
    interface IMySQLDapper
    {
        public Task<IEnumerable<T>> QueryAsync<T>(string sql);
        public T QueryFirst<T>(string sql);

        public T QueryFirstOrDefault<T>(string sql);

        public Task<T> QueryFirstAsync<T>(string sql, object entity = null);

        public Task<T> QueryFirstOrDefaultAsync<T>(string sql, object entity = null);

        public  int Execute(string sql, object entity);

        public Task<int> ExecuteAsync(string sql, object entity);
    }
}

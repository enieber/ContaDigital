using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;


namespace Infrastructure.DataBase.MySql
{
    public class MySQLDapper : IMySQLDapper
    {
        public Task<IEnumerable<T>> QueryAsync<T>(string sql) => SqlMapper.QueryAsync<T>(MySQLConnection.sqlcnn, sql);

        public T QueryFirst<T>(string sql) =>  SqlMapper.QueryFirst<T>(MySQLConnection.sqlcnn, sql);

        public T QueryFirstOrDefault<T>(string sql) => SqlMapper.QueryFirstOrDefault<T>(MySQLConnection.sqlcnn, sql);


        public Task<T> QueryFirstAsync<T>(string sql, object? entity = null) => SqlMapper.QueryFirstAsync<T>(MySQLConnection.sqlcnn, sql, entity);

        public Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? entity = null) => SqlMapper.QueryFirstOrDefaultAsync<T>(MySQLConnection.sqlcnn, sql, entity);

        public int Execute(string sql, object? entity = null) => SqlMapper.Execute(MySQLConnection.sqlcnn, sql, entity);

        public Task<int> ExecuteAsync(string sql, object? entity = null) => SqlMapper.ExecuteAsync(MySQLConnection.sqlcnn, sql, entity);

    }
}

using MySql.Data.MySqlClient;

namespace Infrastructure.DataBase.MySql
{
    public  class MySQLConnection 
    {
        public static MySqlConnection sqlcnn = Connect();

        private static string ConnectionString()
        {
            var cnn = Shared
                .Configurations
                .EnvConfig
                .GetParamEnv("mysqlconnectionstring");

            return cnn;
        }

        private static MySqlConnection Connect()
        {
            var connection = new MySqlConnection(ConnectionString());
            return connection;
        }
    }
}

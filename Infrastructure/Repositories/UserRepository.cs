using Domain.Commands.User;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Infrastructure.DataBase.MySql;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLDapper _command;

        public UserRepository(MySQLDapper command)
        {
            _command = command;
        }

        public QueryUser GetUserId(Guid idUser)
        {
            var sql = $"SELECT * FROM User where iduser = '{idUser}'";

            return _command.QueryFirst<QueryUser>(sql);
        }

        public QueryUserAccountAuth GetUserByCpf(string cpf)
        {
            var sql = $"SELECT " +
                      $"     u.iduser, a.idaccount, u.cpf, u.name, a.password " +
                      $" FROM User u " +
                      $"    LEFT JOIN useraccount a on a.iduser = u.iduser " +
                      $" WHERE u.cpf = '{cpf}'";

            return _command.QueryFirstOrDefault<QueryUserAccountAuth>(sql);
        }

        public bool RegisterUser(User user)
        {
            try
            {
                var sql = $"insert into User(iduser, cpf, name) " +
                    $"values('{user.IdUser}','{user.Cpf}', '{user.Name}')";

                var ret = _command.ExecuteAsync(sql, user);
                if (ret.Exception != null)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditUser(User user)
        {
            try
            {
                var sql = $"update User set name =  '{user.Name}', status = '{user.Status}' where iduser = '{user.IdUser}'";

                var ret = _command.ExecuteAsync(sql, user);
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

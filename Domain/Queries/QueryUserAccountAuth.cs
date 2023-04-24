using System.ComponentModel.DataAnnotations;

namespace Domain.Queries
{
    public class QueryUserAccountAuth
    {
        public Guid IdUser { get; set; }
        public Guid IdAccount { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
    }
}

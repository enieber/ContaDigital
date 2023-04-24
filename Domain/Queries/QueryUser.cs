using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries
{
    public class QueryUser
    {
        public Guid IdUser { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}

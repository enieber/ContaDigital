using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries
{
    public class QueryUserAccount
    {
        public Guid IdUserAccount { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdAccount { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public Guid IdBank { get; set; }
        public string Password { get; set; }
        public string LastPassword { get; set; }
        public DateTime LastAccess { get; set; }
    }
}

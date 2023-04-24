using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries
{
    public class QueryAccount
    {
        public Guid IdAccount { get; set; }
        public Guid IdBank { get; set; }
        public int Number { get; set; }
        public double Balance { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime LastBlocked { get; set; }
        public bool Status { get; set; }
        public bool Blocked { get; set; }
    }
}

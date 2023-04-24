using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries
{
    public class QueryAccountMov
    {
        public Guid IdaccountMov { get; set; }
        public Guid IdtypeTransaction { get; set; }
        public Guid IdAccount { get; set; }
        public string DescTypeTransaction { get; set; }
        public Guid? IdAccountDestination { get; set; }
        public double Value { get; set; }
        public DateTime DateCreate { get; set; }
    }
}

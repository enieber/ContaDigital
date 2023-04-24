using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TypeTransaction
    {
        public Guid IdTypeTransaction { get; set; }
        public string Description { get; set; }
        public bool Credit { get; set; }
    }
}

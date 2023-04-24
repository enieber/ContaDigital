using Shared.FluentValidator;
using Shared.FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account : Notifiable
    {

        public Account(Guid idAccount, int number, Guid idBank, double balance, DateTime dateCreate,
           DateTime? lastBlocked, bool status, bool blocked)
        {
            IdAccount = idAccount;
            IdBank = idBank;
            Number =  number;
            Balance = balance;
            DateCreate = dateCreate;
            LastBlocked = lastBlocked;  
            Status = status;
            Blocked = blocked;

            AddNotifications(new ValidationContract()
                .GuidIsEmptyOrNull(IdAccount, "IdAccount", "O IdAccount não pode ser vazio ou nulo."));
        }

        public Guid IdAccount { get; set; }
        public Guid IdBank { get; set; }
        public int Number { get; set; }
        public double Balance { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? LastBlocked { get; set; }
        public bool Status { get; set; }
        public bool Blocked { get; set; }
    }
}

using Shared.FluentValidator;
using Shared.FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccountMov: Notifiable
    {
        public AccountMov(TypeTransaction typeTransaction, Guid idAccount, Guid? idAccountDestination, double value)
        {
            IdAccountMov = Guid.NewGuid();
            IdAccount = idAccount;
            IdAccountDestination = idAccountDestination;
            IdTypeTransaction = typeTransaction.IdTypeTransaction;    
            Value = value;  
            DateCreate = DateTime.Now;

            AddNotifications(new ValidationContract()
           .GuidIsEmptyOrNull(IdAccount, "IdAccount", "O IdAccount não pode ser vazio ou nulo.")
                .GuidIsEmptyOrNull(IdTypeTransaction, "IdTypeTransaction", "O Tipo de Transação não pode ser vazio ou nulo.")
                .AreNotEquals(Value, "Value", "O Valor não pode ser vazio ou nulo."));

            string[] transfer = { "pix", "ted", "doc" };
            var transctions = Array.FindAll(transfer, s => s.Equals(typeTransaction.Description)).ToList();

            if (transctions.Count > 0)
                AddNotifications(new ValidationContract()
                    .GuidIsEmptyOrNull(idAccountDestination.Value, "IdAccountDestination", "Conta destino não pode ser vazio ou nulo."));
        }

        public Guid IdAccountMov { get; set; }
        public Guid IdtypeTransaction { get; set; }
        public Guid IdTypeTransaction { get; }
        public Guid IdAccount { get; set; }
        public Guid? IdAccountDestination { get; set; }
        public double Value { get; set; }
        public DateTime DateCreate { get; set; }
    }
}

using Shared.FluentValidator;
using Shared.FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User: Notifiable
    {
        public User(Guid idUser, string cpf, string name, bool status)
        {
            IdUser = idUser;
            Cpf = cpf;  
            Name = name;
            Status = status;
              
            AddNotifications(new ValidationContract()
              .GuidIsEmptyOrNull(IdUser, "IdUser", "O IdUser não pode ser vazio ou nulo.")
              .ValidCpf(Cpf, "Cpf", "O Cpf é inválido.")
              .IsNullOrEmpty(Name, "Name", "O Nome não pode ser vazio ou nulo."));
        }

        public Guid IdUser { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}

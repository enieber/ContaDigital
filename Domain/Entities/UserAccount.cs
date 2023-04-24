using Shared.FluentValidator;
using Shared.FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserAccount: Notifiable
    {

        public UserAccount(Guid idUserAccount, Guid idUser, Guid idAccount, 
            string password, string lastPassword, DateTime? lastAccess)
        {
            IdUserAccount = idUserAccount;  
            IdUser = idUser;
            IdAccount = idAccount;
            Password = password;
            LastPassword = lastPassword;
            LastAccess = lastAccess;

            AddNotifications(new ValidationContract()
               .GuidIsEmptyOrNull(IdUser, "IdUser", "O IdUser não pode ser vazio ou nulo."));
            AddNotifications(new ValidationContract()
              .GuidIsEmptyOrNull(IdAccount, "IdAccount", "O IdAccount não pode ser vazio ou nulo."));
            AddNotifications(new ValidationContract()
                .IsNullOrEmpty(Password, "Password", "A senha não pode ser vazio ou nulo."));
        }

        public Guid IdUserAccount { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdAccount { get; set; }
        public string Password { get; set; }
        public string LastPassword { get; set; }
        public DateTime? LastAccess { get; set; }

    }
}

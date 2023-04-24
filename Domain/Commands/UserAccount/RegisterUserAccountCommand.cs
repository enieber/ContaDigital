using Shared.Commands;
using Shared.FluentValidator;
using Shared.FluentValidator.Validation;

namespace Domain.Commands.UserAccount
{
    public class RegisterUserAccountCommand 
    {
        public RegisterUserAccountCommand(Guid idUser, Guid idAccount, string password)
        {
            IdUserAccount =  Guid.NewGuid();
            IdUser = idUser;
            IdAccount = idAccount;
            Password = password;
        }

        public Guid IdUserAccount { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdAccount { get; set; }
        public string Password { get; set; }
        public DateTime LastAccess { get; set; }
    }
}

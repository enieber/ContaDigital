using Shared.Commands;
using Shared.FluentValidator;
using Shared.FluentValidator.Validation;

namespace Domain.Commands.UserAccount
{
    public class EditUserAccountCommand 
    {
        public Guid IdUserAccount { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdAccount { get; set; }
        public string Password { get; set; }
        public string LastPassword { get; set; }
        public DateTime LastAccess { get; set; }

    }
}

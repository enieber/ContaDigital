using Shared.Commands;
using Shared.FluentValidator;
using Shared.FluentValidator.Validation;
namespace Domain.Commands.Account
{
    public class RegisterAccountCommand
    {
        public RegisterAccountCommand(Guid idAccount, Guid idBank, double balance, DateTime dateCreate, DateTime? lastBlocked, bool status, bool blocked)
        {
            IdAccount = idAccount;
            IdBank = idBank;
            Balance = balance;
            DateCreate = dateCreate;
            LastBlocked = lastBlocked;
            Status = status;
            Blocked = blocked;
        }

        public Guid IdAccount { get; set; }
        public Guid IdBank { get; set; }
        public double Balance { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? LastBlocked { get; set; }
        public bool Status { get; set; }
        public bool Blocked { get; set; }
    }
}

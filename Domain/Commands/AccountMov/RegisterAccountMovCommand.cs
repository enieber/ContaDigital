using Domain.Entities;
using Shared.Commands;
using Shared.FluentValidator;
using Shared.FluentValidator.Validation;

namespace Domain.Commands.AccountMov
{
    public class RegisterAccountMovCommand
    {
        public Guid IdTypeTransaction { get; set; }
        public Guid IdAccount { get; set; }
        public Guid? IdAccountDestianation { get; set; }
        public double Value { get; set; }
    }
}

using Shared.Commands;
using Shared.FluentValidator;
using Shared.FluentValidator.Validation;

namespace Domain.Commands.User
{
    public class EditUserCommand 
    {
        public Guid IdUser { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string PassWord { get; set; }
        public string LastPassWord { get; set; }


    }
}

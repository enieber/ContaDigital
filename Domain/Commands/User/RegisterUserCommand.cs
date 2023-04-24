using System;
using System.Collections.Generic;
using Shared.Commands;
using Shared.FluentValidator;
using Shared.FluentValidator.Validation;

namespace Domain.Commands.User
{
    public class RegisterUserCommand 
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string RePassWord { get; set; }
        public bool Status { get; set; }

    }
}

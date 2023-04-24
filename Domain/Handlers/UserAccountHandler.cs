using Domain.Commands;
using Domain.Commands.UserAccount;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using Shared.FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class UserAccountHandler : Notifiable
    {
        private readonly IUserAccountRepository _repository;

        public UserAccountHandler(IUserAccountRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(RegisterUserAccountCommand command)
        {
            var userAccount = new UserAccount(command.IdUserAccount, command.IdUser, command.IdAccount, command.Password, null, null);

            if (userAccount.Invalid)
                return new CommandResult(false, "Por favor, corrija os campos", userAccount.Notifications);

            if (!_repository.RegisterUserAccount(userAccount))
                return new CommandResult(false, "Ocorreu um erro no cadastrado", new { });

            return new CommandResult(true, "Usuário criado com sucesso!", new { });
        }

        public ICommandResult Handle(EditUserAccountCommand command)
        {
            var userAccount = new UserAccount(command.IdUserAccount, command.IdUser, command.IdAccount, command.Password, command.LastPassword, command.LastAccess);

            if (userAccount.Invalid)
                return new CommandResult(false, "Por favor, corrija os campos", userAccount.Notifications);

            if (!_repository.EditUserAccount(userAccount))
                return new CommandResult(false, "Ocorreu um erro na tentativa de atualziar informações", new { });

            return new CommandResult(true, "Dados atualziado com sucesso!", new { });
        }
    }
}

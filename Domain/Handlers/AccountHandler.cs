using Domain.Commands;
using Domain.Commands.Account;
using Domain.Repositories;
using Shared.Commands;
using Shared.FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Handlers
{
    public class AccountHandler : Notifiable
    {
        private readonly IAccountRepository _repository;

        public AccountHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(RegisterAccountCommand command)
        {
            int number = Random.Shared.Next(0, 100000);

            var account = new Account(command.IdAccount, number, command.IdBank, 0, DateTime.Now, null, true, false);

            if (account.Invalid)
                return new CommandResult(false, "Por favor, corrija os campos", account.Notifications);

            if (!_repository.RegisterAccount(account))
                return new CommandResult(false, "Ocorreu um erro no cadastrado", new { });

            return new CommandResult(true, "Conta cadastrada com sucesso!", new { });
        }

        public ICommandResult Handle(EditAccountCommand command)
        {
            var account = new Account(command.IdAccount, command.Number, command.IdBank, command.Balance, DateTime.Now, command.LastBlocked, command.Status, command.Blocked);

            if (account.Invalid)
                return new CommandResult(false, "Por favor, corrija os campos", account.Notifications);

            if (!_repository.EditAccount(account))
                return new CommandResult(false, "Ocorreu um erro na tentativa de atualziar informações", new { });

            return new CommandResult(true, "Conta atualziada com sucesso!", new { });
        }
    }
}

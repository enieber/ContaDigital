using Domain.Commands;
using Domain.Commands.Account;
using Domain.Commands.User;
using Domain.Commands.UserAccount;
using Domain.Repositories;
using Shared.Commands;
using Shared.FluentValidator;
using Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Handlers
{
    public class UserHandler : Notifiable
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IBankRepository _bankRepository;
        private readonly AccountHandler _accountHandler;
        private readonly UserAccountHandler _userAccountHandler;

        public UserHandler(IUserRepository userRepository, IUserAccountRepository userAccountRepository, IAccountRepository accountRepository,  AccountHandler accountHandler, UserAccountHandler userAccountHandler, IBankRepository bankRepository)
        {
            _userRepository = userRepository;
            _userAccountRepository = userAccountRepository;
            _accountRepository = accountRepository;
            _accountHandler = accountHandler;
            _userAccountHandler = userAccountHandler;
            _bankRepository = bankRepository;
        }

        public ICommandResult Handle(RegisterUserCommand command)
        {
            if (string.IsNullOrEmpty(command.PassWord))
                return new CommandResult(false, "Senhas é obrigatório.", new { });

            if (command.PassWord.Length != 6)
                return new CommandResult(false, "Senhas deve conter 6 dígitos.", new { });

            if (string.IsNullOrEmpty(command.PassWord) || (command.RePassWord != command.PassWord))
                return new CommandResult(false, "Senhas não confere.", new { });

            if (_userRepository.GetUserByCpf(command.Cpf) != null)
                return new CommandResult(false, "Usuário já esta cadastrado", new { });

            var user = new User(Guid.NewGuid(), command.Cpf, command.Name, true);

            if (user.Invalid)
                return new CommandResult(false, "Por favor, corrija os campos", user.Notifications);

            //create User
            if (!_userRepository.RegisterUser(user))
                return new CommandResult(false, "Ocorreu um erro no cadastrado", new { });
          
            // create Account
            var bank = _bankRepository.GetBank();
            double balance = 0;
            Guid idAccount = Guid.NewGuid();

            var account = new RegisterAccountCommand(idAccount, bank.IdBank, balance, DateTime.UtcNow, null, true, false);

            var retAcc = _accountHandler.Handle(account);

            //set user account
            if (retAcc.Success)
            {
                var _user = _userRepository.GetUserByCpf(command.Cpf);
                var _account = _accountRepository.GetAccountId(idAccount);

                var useraccount = new RegisterUserAccountCommand(_user.IdUser, _account.IdAccount, command.PassWord);

                var retUsrAcc = _userAccountHandler.Handle(useraccount);

                if (!retUsrAcc.Success)
                    return new CommandResult(false, "Ocorreu um erro no cadastrado", new { });

            }
            else
            {
                return new CommandResult(false, "Ocorreu um erro no cadastrado", new { });
            }

            return new CommandResult(true, "Usuário criado com sucesso!", new { });
        }

        public ICommandResult Handle(EditUserCommand command)
        {
            var user = new User(command.IdUser, command.Cpf, command.Name, command.Status);

            if (user.Invalid)
                return new CommandResult(false, "Por favor, corrija os campos", Notifications);

            var queryUserAccount = _userAccountRepository.GetUserAccountId(user.IdUser);

            if (queryUserAccount != null && string.IsNullOrWhiteSpace(command.PassWord))
            {
                //update user account
                if(queryUserAccount.Password == command.PassWord)
                    return new CommandResult(false, "Por favor, digita uma nova", Notifications);

                var userAccountCommand = new EditUserAccountCommand{
                   IdUserAccount = queryUserAccount.IdUserAccount,
                    IdUser = queryUserAccount.IdUser,
                    IdAccount = queryUserAccount.IdAccount,
                    Password =  command.PassWord,
                    LastPassword = queryUserAccount.LastPassword
                };

               var retUsrAcc = _userAccountHandler.Handle(userAccountCommand);

                if (!retUsrAcc.Success)
                    return new CommandResult(false, "Ocorreu um erro na tentativa de atualziar informações.", new { });
            }      

            if (!_userRepository.EditUser(user))
                return new CommandResult(false, "Ocorreu um erro na tentativa de atualziar informações.", new { });

            return new CommandResult(true, "Dados atualziado com sucesso!", new { });
        }
    }
}

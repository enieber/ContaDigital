using Domain.Commands;
using Domain.Commands.AccountMov;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Domain.Services;
using Shared.Commands;
using Shared.FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class AccountMovHandler :  Notifiable
    {
        private readonly IAccountMovRepository _repository;
        private readonly IAccountMovService _service;
        private readonly ITypeTransactionRepository _typeTransactionrepository;
        private readonly IAccountRepository _accountRepository;

        public AccountMovHandler(IAccountMovRepository repository, IAccountMovService service, ITypeTransactionRepository typeTransactionRepository, IAccountRepository accountRepository)
        {
            _repository = repository;
            _service = service;
            _typeTransactionrepository = typeTransactionRepository;
            _accountRepository = accountRepository;
        }

        public ICommandResult Handle(RegisterAccountMovCommand command)
        {
            var typeTransaction = _typeTransactionrepository.GetTypeTransaction();
            var transaction = typeTransaction.Where(t => t.IdTypeTransaction == command.IdTypeTransaction).ToList();

            if(transaction.Count == 0)
                return new CommandResult(false, "Tipo de transação não encontrada.", new { });


            var transferQuery = transaction.First();
            TypeTransaction transfer  = new TypeTransaction { IdTypeTransaction = transferQuery.IdTypeTransaction, Description = transferQuery.Description, Credit = transferQuery.Credit };

            if (!transfer.Credit)
            {
                var balance = _service.GetBalanceMov(command.IdAccount);

                if ((balance <= 0 || balance < command.Value))
                    return new CommandResult(false, "Você não possui saldo para esta operação.", new { });

                if (command.Value > 1000)
                    return new CommandResult(false, "Limite diário permitido é de R$ 1.000,00 reais.", new { });
            }

            QueryAccount accountDestianation = null;
            if (command.IdAccountDestianation != null)
            {
                accountDestianation = _accountRepository.GetAccountId(command.IdAccountDestianation.Value);
                if(accountDestianation == null)
                    return new CommandResult(false, "Conta destino não encontrada.", Notifications);
            }

            //Create mov Account 
            var accountMov = new AccountMov(transfer, command.IdAccount, command.IdAccountDestianation, command.Value);
            if (accountMov.Invalid)
                return new CommandResult(false, "Por favor, corrija os campos", accountMov.Notifications);

            if (!_repository.RegisterAccountMov(accountMov))
                return new CommandResult(false, "Ocorreu um erro desconhecido. Contate Administrador.", new { });
        
            var newBalance = _service.GetBalanceMov(command.IdAccount);
            var account = _accountRepository.GetAccountId(accountMov.IdAccount);
            account.Balance = newBalance;
            if (!_accountRepository.UpdateBalance(account))
                return new CommandResult(false, "Ocorreu um erro desconhecido. Contate Administrador.", new { });

            //Create Mov Account Destianation
            if(accountDestianation != null)
            {
                List<QueryTypeTransaction>? transactionDestination = typeTransaction.Where(tr => tr.Description == "received").ToList();
                var transferDestinationQuery = transactionDestination.First();
                TypeTransaction transferDestination = new TypeTransaction { IdTypeTransaction = transferDestinationQuery.IdTypeTransaction, Description = transferDestinationQuery.Description, Credit = transferDestinationQuery.Credit };
                var accountMovDestination = new AccountMov(transferDestination, command.IdAccountDestianation.Value, command.IdAccount, command.Value);
                if (!_repository.RegisterAccountMov(accountMovDestination))
                    return new CommandResult(false, "Ocorreu um erro desconhecido. Contate Administrador.", new { });

                newBalance = _service.GetBalanceMov(accountDestianation.IdAccount);
                accountDestianation.Balance = newBalance;
                if (!_accountRepository.UpdateBalance(accountDestianation))
                    return new CommandResult(false, "Ocorreu um erro desconhecido. Contate Administrador.", new { });
            }

            return new CommandResult(true, "Transação realizada com sucesso!", new { });
        }

    }
}

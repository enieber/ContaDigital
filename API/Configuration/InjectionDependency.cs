using Domain.Handlers;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.DataBase.MySql;
using Infrastructure.Repositories;
using Infrastructure.Services;
using System.Reflection;

namespace API.Configuration
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountMovRepository, AccountMovRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<ITypeTransactionRepository, TypeTransactionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();

            return services;

        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<AccountHandler>();
            services.AddScoped< AccountMovHandler>();
            services.AddScoped<UserHandler>();
            services.AddScoped<UserAccountHandler>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountMovService, AccountMovService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<ITypeTransactionService, TypeTransactionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAccountService, UserAccountService>();

            return services;
        }

        public static IServiceCollection AddDataBase(this IServiceCollection services)
        {
            services.AddSingleton<MySQLDapper>();

            return services;
        }
    }
}

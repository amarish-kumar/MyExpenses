/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Modules
{
    using Microsoft.Extensions.DependencyInjection;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Infrastructure.Repositories;
    using MyExpenses.Infrastructure.UnitOfWork;

    public static class InfrastructureModule
    {
        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<ILabelRepository, LabelRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

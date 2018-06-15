/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Modules
{
    using Microsoft.Extensions.DependencyInjection;

    using MyExpenses.Application.Adapters;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.Services;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Services;
    using MyExpenses.Infrastructure.Repositories;
    using MyExpenses.Infrastructure.UnitOfWork;

    public static class ApplicationModule
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

            // Domain Services
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<ILabelService, LabelService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IUserService, UserService>();

            // Application services
            services.AddScoped<IExpenseAppService, ExpenseAppService>();
            services.AddScoped<ILabelAppService, LabelAppService>();
            services.AddScoped<IPaymentAppService, PaymentAppService>();
            services.AddScoped<IUserAppService, UserAppService>();

            // Adapters
            services.AddScoped<IExpenseAdapter, ExpenseAdapter>();
            services.AddScoped<ILabelAdapter, LabelAdapter>();
            services.AddScoped<IPaymentAdapter, PaymentAdapter>();
        }
    }
}

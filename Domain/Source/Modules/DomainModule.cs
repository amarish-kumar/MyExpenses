/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Modules
{
    using Microsoft.Extensions.DependencyInjection;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Services;

    public static class DomainModule
    {
        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            // Domain Services
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<ILabelService, LabelService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}

/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Modules
{
    using Microsoft.Extensions.DependencyInjection;

    using MyExpenses.Application.Interfaces;
    using MyExpenses.Application.Services;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Services;
    using MyExpenses.Infrastructure.Repositories;
    using MyExpenses.Infrastructure.UnitOfWork;

    public static class ApplicationModule
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IExpensesRepository, ExpensesRepository>();
            services.AddScoped<ILabelRepository, LabelRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<ILabelService, LabelService>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IExpenseAppService, ExpenseAppService>();
            services.AddScoped<ILabelAppService, LabelAppService>();
            services.AddScoped<IPaymentAppService, PaymentAppService>();
        }
    }
}

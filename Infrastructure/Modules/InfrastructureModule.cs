/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Modules
{
    using Microsoft.Extensions.DependencyInjection;

    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Interfaces.Services;
    using MyExpenses.Domain.Services;
    using MyExpenses.Infrastructure.Repositories;

    public static class InfrastructureModule
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IExpensesRepository, ExpensesRepository>();
            services.AddScoped<ILabelRepository, LabelRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<ILabelService, LabelService>();
            services.AddScoped<IPaymentService, PaymentService>();

            //services.AddScoped<IExpenseAppService, ExpenseAppService>();
            //services.AddScoped<ILabelAppService, LabelAppService>();
            //services.AddScoped<IPaymentAppService, PaymentAppService>();
        }
    }
}

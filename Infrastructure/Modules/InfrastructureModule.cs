/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Modules
{
    using Microsoft.Extensions.DependencyInjection;

    using MyExpenses.Infrastructure.Interfaces;
    using MyExpenses.Infrastructure.Repositories;

    public static class InfrastructureModule
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IExpensesRepository, ExpensesRepository>();
            services.AddScoped<ILabelRepository, LabelRepository>();
        }
    }
}

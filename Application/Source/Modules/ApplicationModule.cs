/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Modules
{
    using Microsoft.Extensions.DependencyInjection;

    using MyExpenses.Application.Adapters;
    using MyExpenses.Application.AutoMapper;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Application.Services;

    public static class ApplicationModule
    {
        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfiguration.Configure();

            // Application services
            services.AddScoped<IExpenseAppService, ExpenseAppService>();
            services.AddScoped<ILabelAppService, LabelAppService>();
            services.AddScoped<IPaymentAppService, PaymentAppService>();
            services.AddScoped<IUserAppService, UserAppService>();

            // Adapters
            services.AddScoped<IExpenseAdapter, ExpenseAdapter>();
            services.AddScoped<ILabelAdapter, LabelAdapter>();
            services.AddScoped<IPaymentAdapter, PaymentAdapter>();

            DomainModule.ConfigureServices(services);

            InfrastructureModule.ConfigureServices(services);
        }
    }
}

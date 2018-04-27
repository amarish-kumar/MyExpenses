using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyExpenses.WebApplicationMVC.Models;
/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplicationMVC
{
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using MyExpenses.Infrastructure.Context;
    using MyExpenses.Infrastructure.Interfaces;
    using MyExpenses.Infrastructure.Modules;
    using MyExpenses.Infrastructure.Repositories;
    using MyExpenses.WebApplicationMVC.Data;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            string connectionStrings = Configuration.GetConnectionString("SqliteConnectionStrings");
            services.AddDbContext<MyExpensesContext>(options => options.UseSqlite(connectionStrings));

            InfrastructureModule.ConfigureServices(services);

            services.AddDbContext<MyExpensesWebApplicationMVCContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MyExpensesWebApplicationMVCContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

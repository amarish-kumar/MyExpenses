using Microsoft.EntityFrameworkCore;
using MyExpenses.Domain.Models;
namespace MyExpenses.WebApplicationMVC.Data
{
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Infrastructure.Mapping;

    public class WebApplicationMVCContext : DbContext
    {
        public WebApplicationMVCContext (DbContextOptions<WebApplicationMVCContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //LabelMap.Map(modelBuilder);
            //ExpenseMap.Map(modelBuilder);
        }

        public DbSet<MyExpenses.Domain.Models.Label> Label { get; set; }

        public DbSet<MyExpenses.Domain.Models.Expense> Expense { get; set; }
    }
}

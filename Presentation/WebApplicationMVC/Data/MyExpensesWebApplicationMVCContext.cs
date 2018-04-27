namespace MyExpenses.WebApplicationMVC.Data
{
    using Microsoft.EntityFrameworkCore;

    public class MyExpensesWebApplicationMVCContext : DbContext
    {
        public MyExpensesWebApplicationMVCContext (DbContextOptions<MyExpensesWebApplicationMVCContext> options)
            : base(options)
        {
        }

        public DbSet<MyExpenses.Domain.Models.How> How { get; set; }
    }
}

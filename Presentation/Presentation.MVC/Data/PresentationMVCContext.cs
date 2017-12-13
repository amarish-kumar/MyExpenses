using Microsoft.EntityFrameworkCore;
using Presentation.MVC.Models;
/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace Presentation.MVC.Models
{
    using Microsoft.EntityFrameworkCore;

    public class PresentationMVCContext : DbContext
    {
        public PresentationMVCContext (DbContextOptions<PresentationMVCContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Data/myexpenses.db");
            //optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Expense>()
            //    .HasOne(x => x.Tag)
            //    .WithMany(x => x.Expenses)
            //    .HasForeignKey(x => x.TagId)
            //    .HasConstraintName("Expenses_Tag");
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Presentation.MVC.Models.Tag> Tag { get; set; }
    }
}

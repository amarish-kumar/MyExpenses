/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Mapping
{
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Domain.Models;

    public static class ExpenseMap
    {
        public static void Map(ModelBuilder builder)
        {
            builder.Entity<Expense>();
        }
    }
}

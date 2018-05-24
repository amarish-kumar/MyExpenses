/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.UnitOfWork
{
    using System;

    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Infrastructure.Context;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyExpensesContext _context;

        public UnitOfWork(MyExpensesContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            // Method intentionally left empty.
        }

        public int Commit()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

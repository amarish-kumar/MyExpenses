/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.UnitOfWork
{
    using System;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Infrastructure.Context;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMyContext _context;

        public UnitOfWork(IMyContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            // Method intentionally left empty.
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }
    }
}

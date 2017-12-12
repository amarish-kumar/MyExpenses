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
    using MyExpenses.Util.Logger;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyContext _context;
        private readonly ILogService _log;

        public UnitOfWork(MyContext context, ILogService log = null)
        {
            _context = context;
            _log = log;
        }

        public void BeginTransaction()
        {
            _log?.ClearStackLog();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
                _log?.SaveStackLog();
            }
            catch (Exception e)
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

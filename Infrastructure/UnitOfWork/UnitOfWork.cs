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
    using MyExpenses.Util.IoC;
    using MyExpenses.Util.Logger;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMyContext _context;
        private readonly ILogService _logService;

        public UnitOfWork(IMyContext context)
        {
            _context = context;
            _logService = MyKernelService.GetInstance<LogService>();
        }

        public void BeginTransaction()
        {
            _logService.ClearStackLog();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
                _logService.SaveStackLog();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }
    }
}

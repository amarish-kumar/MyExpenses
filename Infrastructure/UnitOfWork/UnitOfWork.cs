/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.Infrastructure.UnitOfWork
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Infrastructure.Context;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;

        public UnitOfWork(MyContext context)
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
                throw;
            }
        }

        public void Rollback()
        {
            var added = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added).Select(c => c.Entity).ToList();

            added.ForEach(
                x =>
                    {
                        var adapter = (IObjectContextAdapter)_context;

                        try
                        {
                            adapter.ObjectContext.DeleteObject(x);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    });

            var objectContext = ((IObjectContextAdapter)_context).ObjectContext;

            //Atualiza os outros objetos dando preferência para o banco de dados
            var entitiesToRefresh = _context
                .ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(c => c.Entity).ToList();

            //Recarrega os dados do banco
            objectContext.Refresh(RefreshMode.StoreWins, entitiesToRefresh);
            entitiesToRefresh.ForEach(x => _context.Entry(x).State = EntityState.Unchanged);
        }
    }
}

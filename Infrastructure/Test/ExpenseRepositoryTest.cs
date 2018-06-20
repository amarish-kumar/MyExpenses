/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.InfrastructureTest
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.Repositories;
    using MyExpenses.Domain.Models;

    [TestClass]
    public class ExpenseRepositoryTest : RepositoryTestBase<Expense, IExpenseRepository>
    {
        [TestInitialize]
        public void Initialize()
        {
            Repository = GetAppService<IExpenseRepository>();
            UnitOfWork = GetAppService<IUnitOfWork>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Repository = null;
            UnitOfWork = null;
        }
    }
}
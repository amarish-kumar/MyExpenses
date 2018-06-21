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
            ModelBase = new Expense();
        }

        [TestMethod]
        public void ExpenseTestInclude()
        {
            // arrange

            // act
            var allObjs = Repository.Get(x => x.Label, x => x.Payment).ToList();

            // assert
            Assert.IsTrue(allObjs.Any());
            allObjs.ForEach(x => 
                {
                    Assert.IsNotNull(x.Label);
                    Assert.IsTrue(x.Label.Expenses.Any());

                    Assert.IsNotNull(x.Payment);
                    Assert.IsTrue(x.Payment.Expenses.Any());
                });
        }
    }
}
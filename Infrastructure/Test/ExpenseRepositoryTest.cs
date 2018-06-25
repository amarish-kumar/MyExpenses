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
    using MyExpenses.InfrastructureTest.Properties;

    [TestClass]
    public class ExpenseRepositoryTest : RepositoryTestBase<Expense, IExpenseRepository>
    {
        [TestInitialize]
        public void Initialize()
        {
            Repository = GetAppService<IExpenseRepository>();
            UnitOfWork = GetAppService<IUnitOfWork>();
            ModelBase = new Expense { Name = Resource.NewExpenseName };
        }

        [TestMethod]
        public void ExpenseTestGetWithInclude()
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

        [TestMethod]
        public void ExpenseTestGetByIdWithInclude()
        {
            // arrange

            // act
            var obj = Repository.GetById(1, x => x.Label, x => x.Payment);

            // assert
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Label);
            Assert.IsTrue(obj.Label.Expenses.Any());
            Assert.IsNotNull(obj.Payment);
            Assert.IsTrue(obj.Payment.Expenses.Any());
        }
    }
}
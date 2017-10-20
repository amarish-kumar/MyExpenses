/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;

    using MyExpenses.Domain.Models;
    using MyExpenses.Infrastructure.Repositories;

    using NUnit.Framework;

    [TestFixture]
    public class DummyTest
    {
        [Test]
        public void DummyTestWhenIsTrue()
        {
            //arrange
            var mockMyViewModel = new Mock<ExpensesRepo> { CallBase = true };
            mockMyViewModel.Setup(x => x.Get(null)).Returns(new List<Expense>
                                                                      {
                                                                          new Expense
                                                                              {
                                                                                  Id = 1,
                                                                                  Name = "Test Name",
                                                                                  Value = 2,
                                                                                  Date = new DateTime()
                                                                              }
                                                                      });

            var list = mockMyViewModel.Object.Get();
            Assert.IsTrue(list.Any());
        }
    }
}

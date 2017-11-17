/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Tests.ServiceMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Moq;

    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;
    using MyExpenses.Util.Results;

    public static class ExpensesServiceMock
    {
        public static Mock<IExpensesService> GetMock(ICollection<Expense> collection)
        {
            Mock<IExpensesService> serviceMock = new Mock<IExpensesService>(MockBehavior.Strict);

            serviceMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Expense, object>>[]>())).Returns(collection);
            serviceMock.Setup(x => x.Remove(It.IsAny<Expense>())).Returns(
                (Expense tmp) =>
                    {
                        var r = collection.FirstOrDefault(x => x.Id == tmp.Id);
                        if (r != null && collection.Remove(r))
                        {
                            return new MyResults(MyResultsType.Ok);
                        }
                        return new MyResults(MyResultsType.Error);
                    });
            serviceMock.Setup(x => x.AddOrUpdate(It.IsAny<Expense>())).Returns(
                (Expense tmp) =>
                    {
                        MyResults validate = tmp.Validate();
                        if (validate.Type != MyResultsType.Ok)
                            return validate;
                        collection.Add(tmp);
                        return new MyResults(MyResultsType.Ok);
                    });
            serviceMock.Setup(x => x.GetById(It.IsAny<long>())).Returns(collection.FirstOrDefault());

            return serviceMock;
        }
    }
}

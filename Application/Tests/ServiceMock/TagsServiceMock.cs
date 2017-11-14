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

    public static class TagsServiceMock
    {
        public static Mock<ITagsService> GetMock(ICollection<Tag> collection)
        {
            Mock<ITagsService> serviceMock = new Mock<ITagsService>(MockBehavior.Strict);

            serviceMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Tag, object>>[]>())).Returns(collection);
            serviceMock.Setup(x => x.Remove(It.IsAny<Tag>())).Returns(
                (Expense tmp) =>
                    {
                        var r = collection.FirstOrDefault(x => x.Id == tmp.Id);
                        if (r != null && collection.Remove(r))
                        {
                            return new MyResults(MyResultsType.Ok, "");
                        }
                        return new MyResults(MyResultsType.Error, "");
                    });
            serviceMock.Setup(x => x.SaveOrUpdate(It.IsAny<Tag>())).Returns(
                (Tag tmp) =>
                    {
                        MyResults validate = tmp.Validate();
                        if (validate.Type != MyResultsType.Ok)
                            return validate;
                        collection.Add(tmp);
                        return new MyResults(MyResultsType.Ok, "");
                    });
            serviceMock.Setup(x => x.GetById(It.IsAny<long>())).Returns(collection.FirstOrDefault());

            return serviceMock;
        }
    }
}

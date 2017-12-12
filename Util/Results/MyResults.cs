/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Util.Results
{
    using System;
    using System.Linq;

    using FluentValidation.Results;

    public class MyResults
    {
        public MyResultsStatus Status { get; private set; }

        public MyResultsAction Action { get; private set; }

        public string Message { get; private set; }

        public bool IsValid => Status == MyResultsStatus.Ok;

        public MyResults(MyResultsStatus status, MyResultsAction action = MyResultsAction.None, string message = "")
        {
            Status = status;
            Action = action;
            Message = message;
        }

        public MyResults(ValidationResult validationResults)
        {
            Message = string.Empty;

            if (validationResults.IsValid)
            {
                Status = MyResultsStatus.Ok;
                Action = MyResultsAction.Validating;
            }
            else
            {
                Status = MyResultsStatus.Error;
                Action = MyResultsAction.Validating;
                validationResults.Errors.ToList().ForEach(x => Message += x.ErrorMessage + Environment.NewLine);
            }
        }
    }

    public enum MyResultsStatus
    {
        Ok,
        Warning,
        Error
    }

    public enum MyResultsAction
    {
        None,
        Validating,
        Creating,
        Updating,
        AddOrUpdate,
        Removing
    }
}

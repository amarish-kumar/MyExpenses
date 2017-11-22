/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Util.Results
{
    public class MyResults
    {
        public MyResultsStatus Status { get; set; }

        public MyResultsAction Action { get; set; }

        public string Message { get; set; }

        public bool IsValid => Status == MyResultsStatus.Ok;

        public MyResults(MyResultsStatus status, MyResultsAction action = MyResultsAction.None, string message = "")
        {
            Status = status;
            Action = action;
            Message = message;
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

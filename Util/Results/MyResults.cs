/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Util.Results
{
    public class MyResults
    {
        public MyResultsType Type { get; set; }

        public MyResultsAction Action { get; set; }

        public string Message { get; set; }

        public MyResults(MyResultsType type, MyResultsAction action = Results.MyResultsAction.None, string message = "")
        {
            Type = type;
            Action = action;
            Message = message;
        }
    }

    public enum MyResultsType
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
        Removing
    }
}

/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.CrossCutting.Results
{
    public class MyResults
    {
        public MyResultsType Type { get; set; }

        public string Action { get; set; }

        public string Message { get; set; }

        public MyResults(MyResultsType type, string action)
        {
            Type = type;
            Action = action;
            Message = null;
        }

        public MyResults(MyResultsType type, string action, string message)
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
}

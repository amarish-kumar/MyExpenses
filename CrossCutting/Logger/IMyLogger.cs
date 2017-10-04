/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.CrossCutting.Logger
{
    using System;

    public interface IMyLogger
    {
        void AppendLog(MyLoggerLevel myLooLevel, string message, Exception ex = null);
     
        void AppendLog(MyLoggerLevel myLooLevel, string action, string path, string obs = "");
     
        void AddStackLog(MyLoggerLevel myLooLevel, string action, string path, string obs = "");
     
        void SaveStackLog();
     
        void SaveStackLogAsError();
     
        void ClearStackLog();
    }
}

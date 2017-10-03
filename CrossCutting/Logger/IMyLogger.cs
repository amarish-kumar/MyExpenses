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
        void AppendLog(MyLoggerLevel logLevel, string message, Exception ex = null);
     
        void AppendLog(MyLoggerLevel logLevel, string action, string path, string obs = "");
     
        void AddStackLog(MyLoggerLevel logLevel, string action, string path, string obs = "");
     
        void SaveStackLog();
     
        void SaveStackLogAsError();
     
        void ClearStackLog();
    }
}

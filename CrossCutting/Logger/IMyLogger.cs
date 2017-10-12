/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.CrossCutting.Logger
{
    using System;

    public interface IMyLogger
    {
        void AppendLog(MyLoggerLevel level, string message, Exception ex = null);

        void AppendLog(MyLoggerLevel level, string action, string path);

        void AppendLog(MyLoggerLevel level, string action, string path, string obs);

        void AddStackLog(MyLoggerLevel level, string action, string path);

        void AddStackLog(MyLoggerLevel level, string action, string path, string obs);
     
        void SaveStackLog();
     
        void SaveStackLogAsError();
     
        void ClearStackLog();
    }
}

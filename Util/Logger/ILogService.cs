/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Util.Logger
{
    using System;

    public interface ILogService
    {
        void AppendLog(LevelLog levelLog, string message, Exception ex = null);

        void AppendLog(LevelLog levelLog, string action, string path, string obs = "");

        void AddStackLog(LevelLog levelLog, string action, string path, string obs = "");

        void SaveStackLog();

        void SaveStackLogAsError();

        void ClearStackLog();
    }
}

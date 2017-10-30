/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Util.Logger
{
    using System;
    using System.Collections.Generic;

    using log4net;

    public class LogService : ILogService
    {
        private static readonly List<KeyValuePair<LevelLog, string>> _stackLog = new List<KeyValuePair<LevelLog, string>>();

        private static readonly ILog _log;

        public void AppendLog(LevelLog levelLog, string message, Exception ex = null)
        {
            if (_log == null)
                return;
            
            switch (levelLog)
            {
                case LevelLog.Info:
                    _log.Info(message);
                    break;
                case LevelLog.Debug:
                    _log.Debug(message);
                    break;
                case LevelLog.Error:
                    _log.Error(message);
                    break;
                case LevelLog.Warn:
                    _log.Warn(message);
                    break;
                case LevelLog.Fatal:
                    _log.Fatal(message, ex);
                    break;
                default:
                    _log.Info(message);
                    break;
            }
        }

        public void AppendLog(LevelLog levelLog, string action, string path, string obs)
        {
            string msg = string.Concat("[", action, "] ", "[", path, "]");
            if (obs.Length > 0)
                msg = string.Concat(msg, " - ", obs);
            AppendLog(levelLog, msg);
        }

        public void AddStackLog(LevelLog levelLog, string action, string path, string obs)
        {
            string msg = string.Concat("[", action, "] ", "[", path, "]");
            if (obs.Length > 0)
                msg = string.Concat(msg, " - ", obs);
            _stackLog.Add(new KeyValuePair<LevelLog, string>(levelLog, msg));
        }

        public void ClearStackLog()
        {
            _stackLog.Clear();
        }

        public void SaveStackLog()
        {
            _stackLog.ForEach(x => AppendLog(x.Key, x.Value));
            ClearStackLog();
        }

        public void SaveStackLogAsError()
        {
            _stackLog.ForEach(x => AppendLog(LevelLog.Error, x.Value));
            ClearStackLog();
        }
    }

    public enum LevelLog
    {
        Info,
        Debug,
        Error,
        Warn,
        Fatal
    }
}

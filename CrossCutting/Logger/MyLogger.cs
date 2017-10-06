/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.CrossCutting.Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Security.Principal;

    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Repository.Hierarchy;

    public class MyLogger : IMyLogger
    {
        private static readonly List<KeyValuePair<MyLoggerLevel, string>> _stackLog = new List<KeyValuePair<MyLoggerLevel, string>>();

        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public MyLogger(string connectionString)
        {
            // Configura o XML do log4net. Atenção, como a ConnectionString não está configurada,
            // sempre irá gerar um erro de conexão.
            XmlConfigurator.Configure();

            // Configura as propriedades globais para o log4net
            GlobalContext.Properties["user"] = WindowsIdentity.GetCurrent().Name;
            GlobalContext.Properties["version"] = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            // Configura a connectionString dinamicamente
            Hierarchy hierarchy = LogManager.GetRepository() as Hierarchy;

            // Capta as inforções do Log4Net na sessão "Appender" do tipo AdoNetAppender
            AdoNetAppender appender = hierarchy?.GetAppenders()
                .OfType<AdoNetAppender>()
                .SingleOrDefault();

            if (appender == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                appender.ConnectionString = connectionString;
                appender.ActivateOptions();
            }
        }

        public void AppendLog(MyLoggerLevel level, string message, Exception ex = null)
        {
            //Salva a mensagem de log
            switch (level)
            {
                case MyLoggerLevel.Debug:
                    _log.Debug(message);
                    break;
                case MyLoggerLevel.Error:
                    _log.Error(message);
                    break;
                case MyLoggerLevel.Warn:
                    _log.Warn(message);
                    break;
                case MyLoggerLevel.Fatal:
                    _log.Fatal(message, ex);
                    break;
                default:
                    _log.Info(message);
                    break;
            }
        }

        public void AppendLog(MyLoggerLevel level, string action, string path)
        {
            AppendLog(level, action, path, string.Empty);
        }

        public void AppendLog(MyLoggerLevel level, string action, string path, string obs)
        {
            string msg = string.Concat("[", action, "] ", "[", path, "]");
            if (!string.IsNullOrEmpty(obs))
            {
                msg = string.Concat(msg, " - ", obs);
            }
            AppendLog(level, msg);
        }

        public void AddStackLog(MyLoggerLevel level, string action, string path)
        {
            AddStackLog(level, action, path, string.Empty);
        }

        public void AddStackLog(MyLoggerLevel level, string action, string path, string obs)
        {
            string msg = string.Concat("[", action, "] ", "[", path, "]");
            if (string.IsNullOrEmpty(obs))
            {
                msg = string.Concat(msg, " - ", obs);
            }
            _stackLog.Add(new KeyValuePair<MyLoggerLevel, string>(level, msg));
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
            _stackLog.ForEach(x => AppendLog(MyLoggerLevel.Error, x.Value));
            ClearStackLog();
        }
    }
}
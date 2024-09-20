using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace League_Master.ApplicationCore.Logging
{
    public class ClarivateFileLogger : ILogger
    {
        protected readonly ClarivateFileLoggerProvider clarivateLoggerFileProvider;

        public ClarivateFileLogger([NotNull] ClarivateFileLoggerProvider clarivateLoggerFileProvider)
        {
            this.clarivateLoggerFileProvider = clarivateLoggerFileProvider;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var fullFilePath = clarivateLoggerFileProvider.Options.FolderPath + "/" + clarivateLoggerFileProvider.Options.FilePath.Replace("{date}", DateTimeOffset.UtcNow.ToString("yyyyMMdd"));
            var logRecord = string.Format("{0} [{1}] {2} {3}", "[" + DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss+00:00") + "]", logLevel.ToString(), formatter(state, exception), exception != null ? exception.StackTrace : "");

            using (StreamWriter sw = File.AppendText(fullFilePath))
            {
                sw.WriteLine(logRecord);
            }
        }
    }
}

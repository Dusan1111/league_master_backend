using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace League_Master.ApplicationCore.Logging
{
    public static class ClarivateFileLoggerExtensions
    {
        public static ILoggingBuilder AddClarivateFileLogger(this ILoggingBuilder builder, Action<ClarivateFileLoggerOptions> configure)
        {
            builder.Services.AddSingleton<ILoggerProvider, ClarivateFileLoggerProvider>();
            builder.Services.Configure(configure);
            return builder;
        }
    }
}

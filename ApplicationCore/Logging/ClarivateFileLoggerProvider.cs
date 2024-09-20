using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;

namespace League_Master.ApplicationCore.Logging
{
    [ProviderAlias("ClarivateFile")]
    public class ClarivateFileLoggerProvider : ILoggerProvider
    {
        public readonly ClarivateFileLoggerOptions Options;

        public ClarivateFileLoggerProvider(IOptions<ClarivateFileLoggerOptions> options)
        {
            Options = options.Value;

            if (!Directory.Exists(options.Value.FilePath))
            {
                Directory.CreateDirectory(options.Value.FilePath);
            }
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ClarivateFileLogger(this);
        }

        public void Dispose()
        {
        }
    }
}


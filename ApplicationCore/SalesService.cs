
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace League_Master.ApplicationCore
{
    public class SalesService 
    {
       
        private readonly ILogger<SalesService> logger;
        public SalesService([NotNull] ILogger<SalesService> logger)
        {
            this.logger = logger;
        }

    }
}

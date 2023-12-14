using Microsoft.Extensions.Logging;
namespace Task_ChangeLogLevel
{
    public class LogLevelChange : ILogLevelChange
    {
        public ILogger<Program> SetLogLevel(LogLevel logLevel)
        {
            var loggerFactory = LoggerFactory.Create(
            builder => builder
                        // add console as logging target
                        .AddConsole()
                        // set minimum level to log
                        .SetMinimumLevel(logLevel)

              );
            var logger = loggerFactory.CreateLogger<Program>();

            return logger;
        }


    }

}
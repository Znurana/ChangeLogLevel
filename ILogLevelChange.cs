using Microsoft.Extensions.Logging;


namespace Task_ChangeLogLevel
{
    internal interface ILogLevelChange
    {
        ILogger<Program> SetLogLevel(LogLevel logLevel);
    }
}
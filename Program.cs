using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Task_ChangeLogLevel
{
    public class Program
    {
        private ILogger<Program> _logger;


        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConsole();
                })
           .AddScoped<Program>()

           .AddScoped<ILogLevelChange, LogLevelChange>()

           .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var program = scope.ServiceProvider.GetRequiredService<Program>();
                var logLevelSetter = scope.ServiceProvider.GetRequiredService<ILogLevelChange>();
                // Set log level from Debug 
                program._logger = logLevelSetter.SetLogLevel(LogLevel.Debug);
                program.Run();
                // Change log level to Warning  dynamically
                program._logger = logLevelSetter.SetLogLevel(LogLevel.Warning);
                program.Run();

            }
        }
        public void Run()
        {
            _logger.LogDebug("This is a Debug message");
            _logger.LogInformation("This is an Information message");
            _logger.LogWarning("This is a Warning message");
            _logger.LogError("This is an Error message");
            _logger.LogCritical("This is an Critical message");

        }

    }
}
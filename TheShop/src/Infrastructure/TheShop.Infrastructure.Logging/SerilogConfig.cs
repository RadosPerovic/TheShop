using Serilog;
using Serilog.Events;

namespace TheShop.Infrastructure.Logging
{
    public static class SerilogConfig
    {
        public static ILogger ConfigureLogging()
        {
            var config = new LoggerConfiguration()
                .WriteTo.Debug()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Warning);

            Log.Logger = config.CreateLogger();

            return Log.Logger;
        }
    }
}

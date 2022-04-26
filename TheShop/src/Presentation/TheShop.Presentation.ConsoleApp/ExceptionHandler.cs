using Microsoft.Extensions.Logging;

namespace TheShop.Presentation.ConsoleApp
{
    public static class ExceptionHandler
    {
        public static void HandleExceptions<T>(object sender, UnhandledExceptionEventArgs args, ILogger<T> logger)
        {
            Exception exception = (Exception)args.ExceptionObject;
            var exceptionMessage = exception.Message;
            var typeName = exception.GetType().Name;

            logger.LogError($"EXCEPTION - Message: {exceptionMessage}");
            ConsoleAppHelper.WriteUnsuccessfulResult(typeName, exceptionMessage);

            Console.ReadKey();
        }
    }
}

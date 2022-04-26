namespace TheShop.Presentation.ConsoleApp
{
    public static class ConsoleAppHelper
    {
        public static void WriteUnsuccessfulResult(string typeName, string exceptionMessage)
        {
            Console.WriteLine("BadRequest() - Type: {0}, Message: {1}", typeName, exceptionMessage);
        }

        public static void WriteSuccessfulResult(string typeName, string data)
        {
            Console.WriteLine("Ok() - Type: {0}, Data : {1}", typeName, data);
        }

    }
}

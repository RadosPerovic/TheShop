namespace TheShop.Core.Application.Responses
{
    public class Result<T> : Result
    {
        public T Data { get; set; }
        public static Result<T> Success(T data) =>
            new Result<T>
            {
                Data = data,
                IsSuccessful = true
            };

        public static Result<T> Failure(string message) =>
            new Result<T>
            {
                Message = message,
                IsSuccessful = false
            };
    }

    public class Result
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        public static Result Failure(string message) =>
            new Result
            {
                Message = message,
                IsSuccessful = false
            };

        public static Result Success() =>
            new Result
            {
                IsSuccessful = true
            };

    }
}

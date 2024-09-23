namespace Domain.Core.Responses
{
    public class ResponseBase
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; }

    }
}


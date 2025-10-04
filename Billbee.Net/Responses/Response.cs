namespace Billbee.Net.Responses
{
    public class Response<T>
    {
        public int ErrorCode { get; set; }

        public string ErrorDescription { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public T Data { get; set; } = default!;
    }
}
namespace EduPortal.Models.HelperClasses
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; } = true;

        public string? Message { get; set; }

        public ServiceResponse() { }

        public ServiceResponse(bool success, string message, T? data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public ServiceResponse<T> SuccessResponse(T data, string message)
            => new (true, message, data);

        public ServiceResponse<T> FailResponse(string message)
            => new(false, message);
    }
}

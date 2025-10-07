namespace EduPortal.Interfaces
{
    public interface IErrorLogger
    {
        public Task LogExceptionAsync(Exception ex, string? path = null, string? userId = null);
        public Task LogServiceErrorAsync(string code, string message, string? layer = null, string? method = null, string? userId = null, string? details = null);
    }
}

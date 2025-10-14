using EduPortal.Data;
using EduPortal.Interfaces;
using EduPortal.Models.Entities;

namespace EduPortal.Services
{
    public class ErrorLogger : IErrorLogger
    {
        private readonly ApplicationDbContext _context;

        public ErrorLogger(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LogExceptionAsync(Exception ex, string? path = null, int? userId = null)
        {
            var log = new ExceptionLogs
            {
                Code = "0000",        // Check information table of codes. 
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Source = ex.Source,
                Path = path,
                UserId = userId,
                Layer = "Middleware"
            };

            _context.ExceptionLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task LogServiceErrorAsync(string code, string message, string? layer = null, string? method = null, int? userId = null, string? details = null)
        {
            var log = new ExceptionLogs
            {
                Code = "1",
                Message = message,
                Details = details,
                Layer = layer ?? "Service",
                Method = method,
                UserId = userId
            };

            _context.ExceptionLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}

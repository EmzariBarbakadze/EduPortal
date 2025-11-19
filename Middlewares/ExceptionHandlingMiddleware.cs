using EduPortal.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace EduPortal.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;

        public ExceptionHandlingMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                using var scope = _scopeFactory.CreateScope();
                var errorLogger = scope.ServiceProvider.GetRequiredService<IErrorLogger>();

                int userId = 0;
                var subClaim = context.User.FindFirst(JwtRegisteredClaimNames.Sub);

                if (subClaim != null && int.TryParse(subClaim.Value, out var parsedUserId))
                    userId = parsedUserId;

                await errorLogger.LogExceptionAsync(ex, context.Request.Path, userId);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Internal Server Error");
            }
        }

    }
}

using Microsoft.Extensions.Diagnostics.Buffering;

namespace CourierService.Api.Middleware
{
    public sealed class LogBufferHttpMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context, PerRequestLogBuffer buffer, ILogger<LogBufferHttpMiddleware> logger)
        {
            try
            {
                await _next(context);

                if (context.Items.TryGetValue("FlushLogBuffer", out var flush) &&
                    flush is true)
                {
                    buffer.Flush();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled HTTP exception");
                buffer.Flush();
                throw;
            }
        }
    }
}
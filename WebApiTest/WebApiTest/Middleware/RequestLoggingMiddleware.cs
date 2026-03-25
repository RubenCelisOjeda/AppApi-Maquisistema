using System.Diagnostics;

namespace ApiProduct.Middleware
{
    /// <summary>
    /// Este Middleware registra el tiempo de respuesta que demora la solicitud
    /// </summary>
    public class RequestLoggingMiddleware
    {
        #region [ Properties ]

        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        #endregion

        #region [ Constructor ]

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        #endregion

        
        +#region [ Methods ]

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();

            _logger.LogInformation(
                     "Request {Method} {Path} responded {StatusCode} in {Time:F2} s",
                     context.Request.Method,
                     context.Request.Path,
                     context.Response.StatusCode,
                     stopwatch.Elapsed.TotalSeconds
             );
        } 

        #endregion
    }
}

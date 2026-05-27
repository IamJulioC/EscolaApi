using EscolaApi.Errors;
using System.Text.Json;
using EscolaApi.Application.Exceptions;

namespace EscolaApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
            
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                int statusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    BadRequestException => StatusCodes.Status400BadRequest,
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError,
                };

                httpContext.Response.StatusCode = statusCode;
                httpContext.Response.ContentType = "application/json";
                var response = _env.IsDevelopment()
                    ? new ApiException(statusCode.ToString(), ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(statusCode.ToString(), ex.Message, "Internal server error");

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);

                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}

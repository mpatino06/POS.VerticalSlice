using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace POS.VerticalSlice.Exceptions;

public class GlobalExceptionHandle : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var problemDetails = new ProblemDetails
        {
            Status = 500,
            Title = "An unexpected error occurred.",
            Detail = $"Internal error {exception.Message} {exception.StackTrace}",
            Type = "Internal Error",
            Instance = httpContext.Request.Path
        };
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}

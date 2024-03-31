using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OneFit.WebApi.Middlewares;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                                Exception exception,
                                                CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails()
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = exception.Message,
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}

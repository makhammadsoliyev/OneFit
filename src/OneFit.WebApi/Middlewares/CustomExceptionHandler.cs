using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OneFit.Service.Exceptions;

namespace OneFit.WebApi.Middlewares;

public sealed class CustomExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                                Exception exception,
                                                CancellationToken cancellationToken)
    {
        if (exception is not CustomException customException)
            return false;

        var problemDetails = new ProblemDetails()
        {
            Title = "Client Exception",
            Status = customException.StatusCode,
            Detail = customException.Message
        };

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}

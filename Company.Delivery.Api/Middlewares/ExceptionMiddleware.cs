using Company.Delivery.Domain;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Company.Delivery.Api.Middlewares;

/// <summary>
/// Convert app exceptions
/// </summary>
public class ExceptionMiddleware
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="context"></param>
    public Task Invoke(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;

        var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (ex is EntityNotFoundException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }

        return Task.CompletedTask;
    }
}
using Newtonsoft.Json;
using TravelAgency.Domain.Common.Exceptions;

namespace TravelAgency.Api.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (TravelAgencyException exception)
        {
            await HandleAgencyExceptionAsync(context, exception);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    public static Task HandleAgencyExceptionAsync(HttpContext context, TravelAgencyException exception)
    {
        var result = JsonConvert.SerializeObject(new
        {
            exception.Status,
            exception.Message,
            exception.Details
        });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception.Status;

        return context.Response.WriteAsync(result);
    }

    public static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var result = JsonConvert.SerializeObject(new
        {
            Status = 500,
            exception.Message,
            Details = ""
        });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;

        return context.Response.WriteAsync(result);
    }
}
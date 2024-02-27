using Core.Exceptios.Handlers;
using Microsoft.AspNetCore.Http;

namespace Core.Exceptios;

public class ExceptionMiddleWare
{
    private readonly HttpExceptionHandler _handler;
    private readonly RequestDelegate _next;

    public ExceptionMiddleWare(RequestDelegate next)
    {
        _handler = new();
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {

            await HandleExceptionAsync(context.Response, exception);
        }
    }

    private Task HandleExceptionAsync(HttpResponse response, Exception exception)
    {
        response.ContentType = "Application/json";
        _handler.Response = response;
        return _handler.HandleExceptionAsync(exception);
    }
}

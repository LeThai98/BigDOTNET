using System;

namespace Middleware.Middleware;

public class FirstSimpleActivatedMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if(context.Request.Path == "/xxx.html")
        {
            context.Response.Headers.Append("XXXMidleware", "Not able access XXX");
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("You can not access this XXX page\n");
        }
        else
        {
            // use Items to pass data between middlewares 
            context.Items.Add("SimpleActivatedMiddleware", "You can access this page from First Middleware");
            context.Response.Headers.Append("SimpleActivatedMiddleware", "You can access this page");
            await next(context);
        }
    }
}

public class SecondSimpleActivatedMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var dataFromFirstMiddleware = context.Items["SimpleActivatedMiddleware"];

        if(dataFromFirstMiddleware != null)
        {
            await context.Response.WriteAsync($"Data from First Middleware: {dataFromFirstMiddleware}\n");
        }
        else
        {
            await context.Response.WriteAsync("Data from First Middleware is not available\n");
        }
        await next(context);
    }
}

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseFirstSimpleActivatedMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<FirstSimpleActivatedMiddleware>();
    }

    public static IApplicationBuilder UseSecondSimpleActivatedMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SecondSimpleActivatedMiddleware>();
    }
}
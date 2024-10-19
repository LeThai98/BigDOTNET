using System;

namespace Middleware.Middleware;

public class HandleMapTest1
{
    private readonly RequestDelegate _next;

    public HandleMapTest1(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await context.Response.WriteAsync("Map Test 1");

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}

public class HandleMapTest2
{
    private readonly RequestDelegate _next;

    public HandleMapTest2(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await context.Response.WriteAsync("Map Test 2");
        
        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}


public static class UseHandleMapMiddleware
{
    public static IApplicationBuilder UseHandleMapTest1(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HandleMapTest1>();
    }

    public static IApplicationBuilder UseHandleMapTest2(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HandleMapTest2>();
    }
}
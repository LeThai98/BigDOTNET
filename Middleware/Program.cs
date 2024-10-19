var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

/*
    Use Use, Map, and Run extension methods to add middleware to the request pipeline.
*/

// Middleware using Use()
app.Use(async (context, next) =>
        {
            // Do something before the next middleware
            await context.Response.WriteAsync("Middleware 1: Before\n");
            await next.Invoke();
            // Do something after the next middleware
            await context.Response.WriteAsync("Middleware 1: After\n");
        });

// Middleware using Map()
// Map defines a sub-pipeline - new branch in the pipeline => it will not call the next middleware after it 
app.Map("/special", subApp =>
{
    subApp.Run(async context =>
    {
        await context.Response.WriteAsync("Mapped Middleware: This is a special path!\n");
    });
});

// Middleware using Run() - This is the Terminate middleware in the pipeline
app.Run(async context =>
{
    await context.Response.WriteAsync("Run Middleware: This is the final handler.\n");
});

app.Run();

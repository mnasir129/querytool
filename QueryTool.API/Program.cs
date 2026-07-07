var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapGet("/", (IConfiguration configuration, IWebHostEnvironment environment) =>
{
    var applicationName =
        configuration["QueryTool:ApplicationName"]
        ?? "QueryTool API";

    var message =
        configuration["QueryTool:Message"]
        ?? "Hello from QueryTool";

    return Results.Ok(new
    {
        application = applicationName,
        message,
        environment = environment.EnvironmentName,
        version = "1.0.0"
    });
});

app.MapHealthChecks("/health");

app.Run();

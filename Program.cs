using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Data;
using Serilog;
using Serilog.Events;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    // Add this line:
    .WriteTo.File(
       path: Path.Combine(AppContext.BaseDirectory, "logs", "log-.txt"),
       rollingInterval: RollingInterval.Day,
       fileSizeLimitBytes: 10 * 1024 * 1024,
       retainedFileCountLimit: 2,
       rollOnFileSizeLimit: true,
       shared: true,
       flushToDiskInterval: TimeSpan.FromSeconds(1))
    .CreateBootstrapLogger();



try
{
    Log.Information("Starting up the service...");
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog((services, lc) => lc
    .ReadFrom.Configuration(builder.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console());

    builder.Services.AddDbContext<FabricsDbContext>(options =>
        options.UseInMemoryDatabase("FabricsDb"));

    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddSwaggerGen();

    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();


    var app = builder.Build();
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<FabricsDbContext>();
        DbSeeder.Seed(db);
    }
    app.UseSerilogRequestLogging(options =>
    {
        // Customize the message template
        options.MessageTemplate = "Handled {RequestPath}";

        // Emit debug-level events instead of the defaults
        options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;

        // Attach additional properties to the request completion event
        options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
        {
            diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
            diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
        };
    });

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI(options => {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

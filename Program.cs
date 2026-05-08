using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using nkay_fabs_backend.Profiles;
using nkay_fabs_backend.Services;
using Serilog;
using Serilog.Events;


Log.Logger = new LoggerConfiguration()
     .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .WriteTo.Console()
    .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Starting up the service...");
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();

    // Add services to the container.

    builder.Services.AddControllers().AddNewtonsoftJson();
    builder.Services.AddScoped<FabricValidationService>();
    builder.Services.AddScoped<IFabricInfoRepository, FabricInfoRepository>();

    builder.Services.AddDbContext<FabricsDbContext>(dbContextOptions =>
    dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("Practice"),
    sqlOptions => {
        // This helps with transient connection blips
        sqlOptions.EnableRetryOnFailure();
    })
    .ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

    var connString = builder.Configuration.GetConnectionString("Practice");
    Console.WriteLine(connString);



    builder.Services.AddSwaggerGen();
    builder.Services.AddAutoMapper(typeof(Program));
    

    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();


    var app = builder.Build();

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


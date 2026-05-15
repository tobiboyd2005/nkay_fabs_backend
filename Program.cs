using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using nkay_fabs_backend.Profiles;
using nkay_fabs_backend.Services;
using Serilog;
using Serilog.Events;
using System.Text;


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

    builder.Services.AddAuthentication();

    builder.Services.AddAuthorization();
    builder.Services.AddScoped<JwtService>();


    builder.Host.UseSerilog();

    // Add services to the container.

    builder.Services.AddControllers().AddNewtonsoftJson();
    builder.Services.AddScoped<FabricValidationService>();
    builder.Services.AddScoped<IFabricInfoRepository, FabricInfoRepository>();

    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IEmailVerificationRepository, EmailVerificationRepository>();
    builder.Services.AddScoped<IOtpVerificationRepository, OtpVerificationRepository>();
    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
    builder.Services.AddScoped<IMessageRepository, MessageRepository>();
    builder.Services.AddScoped<IEmailService, EmailService>();
    builder.Services.AddScoped<IOtpService, OtpService>();

    builder.Services.AddDbContext<FabricsDbContext>(dbContextOptions =>
    dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("NkayDb"),
    sqlOptions =>
    {
        // This helps with transient connection blips
        sqlOptions.EnableRetryOnFailure();
    })
    .ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

    var connString = builder.Configuration.GetConnectionString("NkayDb");
    Console.WriteLine(connString);



    builder.Services.AddSwaggerGen(options =>
    {
        // Define the Bearer auth scheme
        options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Input a valid token to access this API"
        });

        // Require the Bearer token globally across all endpoints
        options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference("bearer", document)] = []
        });
    });

    builder.Services.AddAutoMapper(typeof(Program));

    builder.Services.AddAuthentication("Bearer")
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Authentication:Issuer"],
                ValidAudience = builder.Configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Convert.FromBase64String(builder.Configuration["Authentication:SecretForKey"]!))
            };
        });


    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();




    var app = builder.Build();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

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
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }



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

//using Microsoft.AspNetCore.Authentication.JwtBearer;

//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using Microsoft.IdentityModel.Tokens;
//using nkay_fabs_backend.Services;
//using Scalar.AspNetCore;
//using Microsoft.OpenApi;
//using Serilog;
//using Serilog.Events;
//using System.Text;

//Log.Logger = new LoggerConfiguration()
//     .MinimumLevel.Information()
//    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//    .WriteTo.Console()
//    .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
//    .CreateLogger();

//try
//{
//    Log.Information("Starting up the service...");
//    var builder = WebApplication.CreateBuilder(args);

//    builder.Services.AddAuthentication(options =>
//    {
//        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    })
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["Jwt:Issuer"],
//            ValidAudience = builder.Configuration["Jwt:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(
//                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
//        };
//    });

//    builder.Services.AddAuthorization();
//    builder.Services.AddScoped<JwtService>();

//    builder.Host.UseSerilog();

//    builder.Services.AddControllers().AddNewtonsoftJson();
//    builder.Services.AddScoped<FabricValidationService>();
//    builder.Services.AddScoped<IFabricInfoRepository, FabricInfoRepository>();

//    builder.Services.AddDbContext<FabricsDbContext>(dbContextOptions =>
//    dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("NkayDb"),
//    sqlOptions => {
//        sqlOptions.EnableRetryOnFailure();
//    })
//    .ConfigureWarnings(warnings =>
//        warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

//    // Built-in OpenAPI
//    builder.Services.AddOpenApi();

//    builder.Services.AddAutoMapper(typeof(Program));

//    builder.Services.AddCors(options =>
//    {
//        options.AddPolicy("AllowAll", policy =>
//        {
//            policy.AllowAnyOrigin()
//                  .AllowAnyMethod()
//                  .AllowAnyHeader();
//        });
//    });

//    var app = builder.Build();


//    app.UseHttpsRedirection();
//    app.UseAuthentication();
//    app.UseAuthorization();

//    app.UseSerilogRequestLogging(options =>
//    {
//        options.MessageTemplate = "Handled {RequestPath}";
//        options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;
//        options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
//        {
//            diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
//            diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
//        };
//    });

//    if (app.Environment.IsDevelopment())
//    {
//        app.MapOpenApi();


//        app.MapScalarApiReference("/docs", options =>
//            {
//                options.Title = "Nkay Fabs API Documentation";
//                options.DarkMode = true;
//                options.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
//                options.CustomCss = "";
//                options.AddPreferredSecuritySchemes("Bearer")
//                .AddHttpAuthentication("Bearer", auth =>
//                {
//                    auth.Token = "";
//                });
//            });
//    }


//    app.MapControllers();
//    app.Run();
//}
//catch (Exception ex)
//{
//    Log.Fatal(ex, "Application terminated unexpectedly");
//}
//finally
//{
//    Log.CloseAndFlush();
//}

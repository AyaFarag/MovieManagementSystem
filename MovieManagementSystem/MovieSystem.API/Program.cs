using MovieSystem.Infrastructure.Presistance.Configrations;
using MovieSystem.Application.Configrations;
using MovieSystem.API.Configrations;
using MovieSystem.API.Middleware;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.Contracts.Service;
using Microsoft.Graph.Models.ExternalConnectors;
using AspNetCoreRateLimit;
using Serilog;
using Asp.Versioning;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddAPIServices(builder.Configuration);
//builder.Host.UseSerilog((context, config) =>
//{
//    config.WriteTo.Console()
//          .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
//          .WriteTo.Seq("http://localhost:5341"); // Replace with your Seq server URL
//});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
    options.AddPolicy("SpecificOrigins", builder =>
    {
        builder.WithOrigins("https://example.com", "https://anotherdomain.com")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
    options.AddPolicy("CustomPolicy", builder =>
    {
        builder.WithOrigins("https://example.com")
               .WithMethods("GET", "POST") // Allow only GET and POST methods
               .WithHeaders("Content-Type", "Authorization") // Allow specific headers
               .AllowCredentials(); // Allow cookies or credentials
    });
});
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true; // Include version info in responses
    options.AssumeDefaultVersionWhenUnspecified = true; // Default version
    options.DefaultApiVersion = ApiVersion.Default; // Set default version
    options.ApiVersionReader = ApiVersionReader.Combine(
        new HeaderApiVersionReader("X-API-Version"),
        new QueryStringApiVersionReader("version"));
});

//builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddMemoryCache();

builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddInMemoryRateLimiting();
//builder.Services.AddClientRateLimiting();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
// Add security headers middleware
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
    context.Response.Headers.Add("Referrer-Policy", "no-referrer");

    await next.Invoke();
});
app.UseHttpsRedirection();

app.UseMiddleware<MovieWatchMiddleware>();
app.UseMiddleware<PaidUserMiddleware>();
app.UseMiddleware<IpWhitelistMiddleware>();
app.UseMiddleware<ApiKeyMiddleware>();
app.UseMiddleware<FixedWindowRateLimitingMiddleware>();
app.UseMiddleware<UserPaymentBasedRateLimitingMiddleware>();
app.UseMiddleware<IpBasedRateLimitingMiddleware>();
app.UseMiddleware<LoginAttemptThrottlingMiddleware>();
app.UseMiddleware<CustomRateLimitMiddleware>();

app.UseIpRateLimiting();

app.UseCors("AllowAll");
app.UseCors("SpecificOrigins");
app.UseCors("CustomPolicy");

app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();

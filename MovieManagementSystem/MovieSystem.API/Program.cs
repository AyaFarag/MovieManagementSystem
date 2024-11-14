using MovieSystem.Infrastructure.Presistance.Configrations;
using MovieSystem.Application.Configrations;
using MovieSystem.API.Configrations;
using MovieSystem.API.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddAPIServices(builder.Configuration);



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


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<MovieWatchMiddleware>();
app.UseMiddleware<PaidUserMiddleware>();
app.UseMiddleware<IpWhitelistMiddleware>();

app.MapControllers();

app.Run();

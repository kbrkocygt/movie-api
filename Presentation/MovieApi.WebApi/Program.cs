

using MovieApi.Persistence.Context;
using MovieApi.WebApi.Extensions;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieContext>();
// Add services to the container.

builder.Services.AddIdentityServices().
AddMediatRServices()
.AddSwaggerServices()
.AddApplicationServices();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API V1");
        x.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();



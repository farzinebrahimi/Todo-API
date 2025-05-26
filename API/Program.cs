

using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

/*------- Add services to the container. -------*/
builder.Services.AddApplicationServices(builder.Configuration);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors(x =>
    x.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:4200", "https://localhost:4200")
        .AllowCredentials());

app.MapControllers();

app.Run();

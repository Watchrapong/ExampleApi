using Example.Api.Middlewares;
using ExampleApi.Data;
using ExampleApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<ExampleApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExampleApiConn") ?? throw new ArgumentNullException("ExampleApiConn"));
});
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

app.UseCustomExceptionHandler();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
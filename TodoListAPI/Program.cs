using TodoListAPI.Models;
using TodoListAPI.Implements;
using TodoListAPI.Services;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<EFDataContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("EFDataContext"),
        new MySqlServerVersion(new Version(6, 0, 0))
    )
);

builder.Services.AddScoped<ITodoListService, TodoListService>();

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
app.UseCors("MyAllowSpecificOrigins"); // Specify the CORS policy name here



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

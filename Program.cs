using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

if (builder.Environment.EnvironmentName != "Testing")
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=todo.db"));
}

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Esta línea permite que WebApplicationFactory<TodoApi.Program> funcione
public partial class Program { }
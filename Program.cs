using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using template_dotnet.Models;
using template_dotnet.Repository;
using template_dotnet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IDboRepository<>), typeof(DboRepository<>));
builder.Services.AddScoped(typeof(IExampleService), typeof(ExampleService));
builder.Services.AddScoped(typeof(ISSExampleService), typeof(SSExampleService));
builder.Services.AddScoped(typeof(ISSRExampleService), typeof(SSRExampleService));


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
var app = builder.Build();

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

using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RYMtool.Core;
using RYMtool.Infrastructure;
using RYMtool.API;
using DependencyInjection = RYMtool.Core.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(DependencyInjection))));
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Albums"));
builder.Services.AddHttpLogging(opt => 
    opt.LoggingFields = HttpLoggingFields.RequestMethod | 
                        HttpLoggingFields.RequestHeaders | 
                        HttpLoggingFields.RequestQuery |
                        HttpLoggingFields.RequestBody|
                        HttpLoggingFields.ResponseBody);
builder.Services
    .AddApplication()
    .AddInfrastructure();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddTransient(ser => ser.GetRequiredService<IOptions<AppSettings>>().Value);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.AddSeedData();
app.UseHttpLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<ErrorHandlerMiddleware>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
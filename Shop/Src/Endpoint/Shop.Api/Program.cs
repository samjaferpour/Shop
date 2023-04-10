using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Shop.Api.Helper;
using Shop.Application.CQRS.CategoryFeatures.Commands;
using Shop.Persistence.Contexts;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Contexts
builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShopConStr")));

// Add Serilog
var logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Seq("http://localhost:5341",
        Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//Add Seq
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSeq(builder.Configuration.GetSection("Seq"));
});


// Ioc Register
builder.Services.AddRepositories();
builder.Services.AddUnitOfWork();
builder.Services.AddCustomServices();
builder.Services.AddValidators();
builder.Services.AddCors();
builder.Services.AddAoutomapper();
builder.Services.AddMediator();
builder.Services.AddRabbitMqPublisher();

// Add CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "MyPolicy",
//                      policy =>
//                      {
//                          policy.WithOrigins("http://192.168.1.107:3000");
//                      });
//});
//builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
//{
//    builder.WithOrigins("http://192.168.1.107:3000").AllowAnyMethod().AllowAnyHeader();
//}));
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(
        options => options.WithOrigins("MyPolicy").AllowAnyMethod()
    );
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

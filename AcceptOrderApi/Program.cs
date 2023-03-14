
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.RabbitMQ(CreateUsingRabbitMq(), "my-exchange")
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog((builderContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(builderContext.Configuration)
    .WriteTo.Logger(Log.Logger)
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>();

// ---------------Service-------------------- /
builder.Services.AddScoped(typeof(IOrderDataService), typeof(OrderDataManager));
// ----------------DAL------------------ /
builder.Services.AddScoped<IOrderDataDal, OrderDataRepository>();

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

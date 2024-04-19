using DCXAir.Application.Services;
using DCXAir.Domain.Entities;
using DCXAir.Domain.Interfaces;
using DCXAir.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMemoryCache();


// Dependency injection
builder.Services.AddSingleton<IFlightRepository, FlightRepository>();
builder.Services.AddSingleton<IFlightService, FlightService>();
builder.Services.AddSingleton<ICurrencyExchangeRepository, CurrencyExchangeRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
}

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

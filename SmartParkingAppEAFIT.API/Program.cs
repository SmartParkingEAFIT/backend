// <copyright file="Program.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

using SmartParkingAppEAFIT.API.Extensions;
using SmartParkingAppEAFIT.API.Hubs;
using SmartParkingAppEAFIT.Application.Extensions;
using SmartParkingAppEAFIT.Infrastructure.Extensions;

// Create the web application builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure infrastructure services (database, repositories, etc.)
builder.Services.AddInfrastructure(builder.Configuration);

// Configure application services (business logic, use cases, etc.)
builder.Services.AddApplicationServices();

// Configure FluentValidation validators
builder.Services.AddFunctionValidators();

// Register HTTP client for making external HTTP requests
builder.Services.AddHttpClient();

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger with custom settings
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new () { Title = "SmartParkingApp EAFIT API", Version = "v1", Description = "API SmartParkingApp EAFIT", });
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Add Controllers with JSON options
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

// Add SignalR for real-time communication
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowFrontend");

// Enable authentication
app.UseAuthentication();

// Enable authorization
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.MapHub<ChatHub>("/chat");

app.Run();

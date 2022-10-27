using CarPoolApi;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;
using System.Reflection;
using CarPoolApi.Business;
using CarPoolApi.Business.Interfaces;
using CarPoolApi.Data;
using CarPoolApi.Data.Interfaces;
using CarPoolApi.Data.Provider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CarPool API",
        Description = "An ASP.NET Core Web API for managing CarPools, their Users and their Locations",
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.ExampleFilters();
});

builder.Services.AddSingleton<LocationDtoProvider>();
builder.Services.AddSingleton<CarPoolDtoProvider>();
builder.Services.AddSingleton<UserDtoProvider>();

builder.Services.AddSingleton<LocationModelProvider>();
builder.Services.AddSingleton<CarPoolModelProvider>();
builder.Services.AddSingleton<UserModelProvider>();

builder.Services.AddSwaggerExamplesFromAssemblyOf<LocationDtoProvider>();
builder.Services.AddSwaggerExamplesFromAssemblyOf<LocationModelProvider>();

builder.Services.AddScoped<ICarPoolBusinessService, CarPoolBusinessService>();
builder.Services.AddScoped<ILocationBusinessService, LocationBusinessService>();
builder.Services.AddScoped<IUserBusinessService, UserBusinessService>();

builder.Services.AddScoped<ICarPoolDataService, CarPoolDataService>();
builder.Services.AddScoped<ILocationDataService, LocationDataService>();
builder.Services.AddScoped<IUserDataService, UserDataService>();

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
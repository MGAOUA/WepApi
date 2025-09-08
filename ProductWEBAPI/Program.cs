using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProductWEBAPI.Mappings;
using ProductWEBAPI.Models;
using static ProductWEBAPI.Mappings.ProductProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(cfg =>
{
    // Manual configuration (not typical if using Profiles)
    cfg.CreateMap<CreateProductDto, Product>(); // Map DTO to Entity
    cfg.CreateMap<Product, ProductDto>();        // Map Entity to DTO
});

// Registers all validators in the assembly
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
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

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    // Code executed on the way IN (handling the request)
    Console.WriteLine($"Request received for: {context.Request.Path}");

    await next.Invoke(); // Pass the request to the next middleware

    // Code executed on the way OUT (handling the response)
    Console.WriteLine("Response sent.");
});

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(name: "default",
    pattern: "{controller=Products}/{äction=Index}/{ïd?}"
    );
app.Run();

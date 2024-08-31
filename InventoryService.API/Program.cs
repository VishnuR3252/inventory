using Serilog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using InventoryService.Application;
using InventoryService.Infrastructure;
using InventoryService.Infrastructure.Data;
using CommonService.Helpers;

var builder = WebApplication.CreateBuilder(args);
// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Use Serilog for logging
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddApplication().AddInfrastructure();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddControllers();

// Configure API versioning
builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver")
    );
});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandling>();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS
app.UseCors(policy =>
{
    policy.AllowAnyHeader()
          .AllowAnyMethod()
          .AllowAnyOrigin();
});

// Enable request logging with Serilog
app.UseSerilogRequestLogging();

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Use authorization middleware (if needed)
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Run the application
app.Run();

using LeaveManagementSystem_Backend.Data;
using LeaveManagementSystem_Backend.Services;
using LeaveManagementSystem_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


// Database

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new Exception("DefaultConnection missing");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));



// Dependency Injection

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ILeaveService, LeaveService>();



// CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});



// Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Leave Management API",
        Version = "v1"
    });
});

var app = builder.Build();



// Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leave Management API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();



app.MapControllers();

app.Run();
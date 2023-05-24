using SafetyDiscussions.Models.Interfaces;
using SafetyDiscussions.Repositories.Repositories;
using SafetyDiscussions.Services.AutoMapper;
using SafetyDiscussions.Services.Interfaces;
using SafetyDiscussions.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AutoMapper 
builder.Services.AddAutoMapper(typeof(SafetyDiscussionMapper));

// Add your custom services
builder.Services.AddScoped<ISafetyDiscussionsService, SafetyDiscussionsService>();
builder.Services.AddSingleton<ISafetyDiscussionsRepository, SafetyDiscussionsRepository>();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Specify the allowed origin(s) of your Angular application
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();

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

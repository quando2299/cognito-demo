using CognitoDemo.API.MappingProfile;
using CognitoDemo.Application.Interfaces;
using CognitoDemo.Application.MappingProfile;
using CognitoDemo.Application.Services;
using CognitoDemo.Core.Interfaces;
using CognitoDemo.Infrastructure.Persistence;
using CognitoDemo.Infrastructure.Repositories;
using CognitoDemo.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApiMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ServiceMappingProfile).Assembly);

// Register Services
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();
app.Run();

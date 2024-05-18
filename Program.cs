using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using TripPlanner.Context;
using TripPlanner.Interface;
using TripPlanner.Repository;
using TripPlanner.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SeniorDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SawagarConnection")));


builder.Services.AddControllers();
// Set the ExcelPackage license context
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ITripRepository, TripRepository>();
builder.Services.AddTransient<ITripService, TripService>();

builder.Services.AddTransient<IUserTableRepository, UserTableRepository>();
builder.Services.AddTransient<IUserTableService, UserTableService>();

builder.Services.AddTransient<IUserTripRepository, UserTripRepository>();
builder.Services.AddTransient<IUserTripService, UserTripService>();

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

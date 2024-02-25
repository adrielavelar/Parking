using Parking.Application.Interfaces;
using Parking.Application.Services;
using Parking.Data.Interfaces;
using Parking.Data.Repositories;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetSection("ParkingConnection").Value;
Environment.SetEnvironmentVariable("DBCONN", connectionString);

builder.Services.AddSingleton<IVacancyService, VacancyService>();
builder.Services.AddSingleton<IRecordRepository, RecordRepository>();
builder.Services.AddSingleton<IVacancyConfiguration, VacancyConfigurationRepository>();

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

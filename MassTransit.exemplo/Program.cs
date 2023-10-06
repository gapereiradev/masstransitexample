using Application;
using AutoMapper;
using Domain.Customer;
using Infrastructure.Mappings;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


#region AutoMapper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});
builder.Services.AddSingleton(config.CreateMapper());
#endregion

#region MySQL
string connectionString = builder.Configuration.GetConnectionString("MySql");

builder.Services.AddDbContextPool<CustomerContext>(options => options
    .UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28)))
    .UseLoggerFactory(
        LoggerFactory.Create(
            logging => logging
                .AddConsole()
                .AddFilter(level => level >= LogLevel.Information)))
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);
#endregion

#region Repos e Services
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICreateCustomerService, CreateCustomerService>();
builder.Services.AddScoped<IUpdateBirthDateService, UpdateBirthDateService>();
builder.Services.AddScoped<IGetCustomerByIdService, GetCustomerByIdService>();
#endregion

#region Swagger

#endregion

#region MassTransit

#endregion

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();

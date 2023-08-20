using Enviroment.Application.Handlers.CommandHandlers;
using Enviroment.Core.Repositories.Command;
using Enviroment.Core.Repositories.Query;
using Enviroment.Core.Repositories.Query.Base;
using Enviroment.Infrastructure.Data;
using Enviroment.Infrastructure.Repositories.Command;
using Enviroment.Infrastructure.Repositories.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(StartupBase));
builder.Services.AddScoped<IDbConector, DbConnector>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateLicenseHandler).Assembly));
builder.Services.AddTransient<ILicenseQueryRepository, LicenseQueryRepository>();
builder.Services.AddTransient<ILinceseCommandRepository, LicensesCommandRepository>();
builder.Services.AddTransient<IClientQueryRepository, ClientQueryRepository>();




var app = builder.Build();

IConfiguration configuration = app.Configuration;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Enviroment.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

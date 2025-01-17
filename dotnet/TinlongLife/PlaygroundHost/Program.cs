using Microsoft.EntityFrameworkCore;
using PlaygroundHost;
using TinlongLife.Data;
using TinlongLife.Domain.Interfaces;
using TinlongLife.Domain.Models;
using TinlongLife.Domain.Operations;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.AddSqlServerDbContext<TinlongLifeDbContext>(connectionName: "TinlongLife");
//var connString = builder.Configuration.GetConnectionString("TinlongLifeDatabase");
//builder.Services.AddDbContext<TinlongLifeDbContext>(options => options.UseSqlServer(connectionString: connString));
builder.Services.AddScoped<IRepository<LifePolicy>, LifePolicyRepository>();
builder.Services.AddScoped<LifePolicyService>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
await host.RunAsync();

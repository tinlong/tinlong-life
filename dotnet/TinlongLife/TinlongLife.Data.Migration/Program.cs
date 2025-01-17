using TinlongLife.Data;
using TinlongLife.Data.Migration;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
	.WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));
builder.AddSqlServerDbContext<TinlongLifeDbContext>("TinlongLife");

var host = builder.Build();
host.Run();

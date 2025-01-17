var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql", port: 1433)
	.WithLifetime(ContainerLifetime.Persistent)
	.WithDataVolume();

var db = sql.AddDatabase("TinlongLife");

var migration = builder.AddProject<Projects.TinlongLife_Data_Migration>("tinlonglife-data-migration")
	.WithReference(db);

builder.AddProject<Projects.PlaygroundHost>("playgroundhost")
	.WithReference(db)
	.WaitFor(db)
	.WaitForCompletion(migration);

builder.Build().Run();
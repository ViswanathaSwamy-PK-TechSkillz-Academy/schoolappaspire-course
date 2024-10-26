var builder = DistributedApplication.CreateBuilder(args);

var sqldbConnectionString = builder.AddConnectionString("SqlDbConnStr");

builder
    .AddProject<Projects.School_API>("school-api")
    .WithExternalHttpEndpoints()
    .WithReference(sqldbConnectionString);

builder.Build().Run();

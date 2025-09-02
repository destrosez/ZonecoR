var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ZonecoR>("zonecor");

builder.Build().Run();

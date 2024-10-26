using School.API.Extensions;
using School.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
_ = builder.Services.ConfigureDependedServices(builder.Configuration);

var app = builder.Build();

_ = app.ConfigureHttpRequestPipeline();

app.Run();

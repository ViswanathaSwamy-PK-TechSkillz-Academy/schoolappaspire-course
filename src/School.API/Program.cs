using School.API.Extensions;
using School.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
_ = builder.Services.AddConfiguredServices(builder.Configuration);

var app = builder.Build();

_ = app.UseConfiguredHttpRequestPipeline();

app.Run();

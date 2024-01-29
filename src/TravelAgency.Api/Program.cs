using FastEndpoints;
using FastEndpoints.Swagger;
using TravelAgency.Api;
using TravelAgency.Application;
using TravelAgency.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors(options => {
    options.AddPolicy("MyPolicy", builder => {
    // TODO: set defaults origins.
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();        
    });
});

var app = builder.Build();
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();
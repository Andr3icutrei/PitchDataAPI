using Microsoft.EntityFrameworkCore;
using PitchData.Database;
using PitchData.Database.Context;
using PitchData.Infrastructure.Config;
using PitchData.Infrastructure;
using PitchData.Core.Services.Interfaces;
using PitchData.Core.Services;
using PitchData.Database.Repositories.Interfaces;
using PitchData.Database.Repositories;
using PitchData.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddServices();
builder.Services.AddRepositories();

var app = builder.Build();

AppConfig.Init(app.Configuration);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

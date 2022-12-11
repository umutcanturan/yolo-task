using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using yolo.common.models;
using yolo.core.configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppData>(builder.Configuration.GetSection("Data"));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DIConfigurator.Inject(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
// following code can be moved to an extension/middleware
app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            var error = new ErrorResponse()
            {
                StatusCode = context.Response.StatusCode,
                Message = contextFeature.Error?.Message ?? "Internal Server Error."
            };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
    });
});
app.MapControllers();

app.Run();


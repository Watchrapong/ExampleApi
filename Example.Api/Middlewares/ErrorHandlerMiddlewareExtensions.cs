using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using Example.Api.Models;
using ExampleApi.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Example.Api.Middlewares;

public static class ErrorHandlerMiddlewareExtensions
{
    public static void UseCustomExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = MediaTypeNames.Application.Json;
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var jsonConfig = new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    jsonConfig.Converters.Add(new JsonStringEnumConverter());

                    var response = new FailResponse();

                    context.Response.StatusCode = StatusCodes.Status200OK;

                    switch (contextFeature.Error)
                    {
                        case ServiceException se:
                            response.Code = se.Code;
                            response.Message = se.Message;
                            break;
                        case UnauthorizedAccessException uae:
                            response.Code = "Unauthorized";
                            response.Message = uae.Message;
                            break;
                        default:
                            response.Message = "Internal Server Error";
                            break;
                    }

                    await context.Response.WriteAsJsonAsync(response, jsonConfig);
                }
            });
        });
    }
}

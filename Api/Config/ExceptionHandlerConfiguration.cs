using System.Net.Mime;
using Api.Models.ErrorModels;
using Api.Services.Logging;
using Microsoft.AspNetCore.Diagnostics;

namespace Api.Config;

public static class ExceptionHandlerConfiguration
{
    public static void ConfigureErrorHandler(this WebApplication app, ILogService logger)
    {
        app.UseExceptionHandler(errorHandler =>
        {
            errorHandler.Run(async context =>
            {
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var contextFeatures = context.Features.Get<ExceptionHandlerFeature>();
                if (contextFeatures != null)
                {
                    context.Response.StatusCode = contextFeatures.Error switch
                    {
                        NotFoundError => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    logger.Error($"Something went wrong: {contextFeatures.Error}");

                    await context.Response.WriteAsync(new ErrorDetails
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeatures.Error.Message
                    }.ToString());
                }
            });
        });
    }
}
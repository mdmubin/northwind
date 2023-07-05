using System.Net.Mime;
using Api.Models.ErrorModels;
using Api.Services.Logging;
using Microsoft.AspNetCore.Diagnostics;

namespace Api.Services;

public static class ExceptionHandlerService
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILogService logger)
    {
        app.UseExceptionHandler(errorHandler =>
        {
            errorHandler.Run(async context =>
            {
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeatures != null)
                {
                    context.Response.StatusCode = contextFeatures.Error switch
                    {
                        NotFoundError => StatusCodes.Status404NotFound,
                        BadRequestError => StatusCodes.Status400BadRequest,
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
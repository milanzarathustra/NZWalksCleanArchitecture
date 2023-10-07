using NZWalksCleanArch.API.Middlewares.GlobalExceptionHandling.Exceptions;
using System.Net;
using Serilog.Context;
using NZWalksCleanArch.Entities.Models;
using Serilog;

namespace NZWalksCleanArch.API.Middlewares.GlobalExceptionHandling;

public sealed class ExceptionHandlerMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> logger;
    private readonly RequestDelegate next;

    public ExceptionHandlerMiddleware(
        ILogger<ExceptionHandlerMiddleware> logger,
        RequestDelegate next)
    {
        this.logger = logger;
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleException(context, exception);
        }
    }

    private static async Task HandleException(HttpContext context, Exception exception)
    {
        string errorId = Guid.NewGuid().ToString();
        LogContext.PushProperty("ErrorId", errorId);
        LogContext.PushProperty("StackTrace", exception.StackTrace);

        var errorResult = new ErrorResult
        {
            Source = exception.TargetSite?.DeclaringType?.FullName,
            Exception = exception.Message.Trim(),
            ErrorId = errorId,
            SupportMessage = $"Provide the Error Id: {errorId} to the support team for further analysis."
        };

        errorResult.Messages.Add(exception.Message);

        if (exception is not CustomException && exception.InnerException != null)
        {
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }
        }

        switch (exception)
        {
            case CustomException e:
                errorResult.StatusCode = (int)e.StatusCode;
                if (e.ErrorMessages is not null)
                    errorResult.Messages = e.ErrorMessages;
                break;
            case KeyNotFoundException:
                errorResult.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            default:
                errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        Log.Error($"{errorResult.Exception} Request failed with Status Code {context.Response.StatusCode} and Error Id {errorId}.");

        var response = context.Response;
        if (!response.HasStarted)
        {
            response.ContentType = "application/json";
            response.StatusCode = errorResult.StatusCode;

            var error = new
            {
                Id = errorId,
                ErrorMessage = "Something went wrong! We are logging into resolving this."
            };

            await response.WriteAsJsonAsync(error);
        }
        else
        {
            Log.Warning("Can't write error response. Response has already started.");
        }
    }
}

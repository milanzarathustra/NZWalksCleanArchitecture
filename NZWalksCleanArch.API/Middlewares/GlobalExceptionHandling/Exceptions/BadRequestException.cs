using System.Net;

namespace NZWalksCleanArch.API.Middlewares.GlobalExceptionHandling.Exceptions;

public class BadRequestException : CustomException
{
    public BadRequestException(string message) : base(message, null, HttpStatusCode.BadRequest)
    {
    }
}

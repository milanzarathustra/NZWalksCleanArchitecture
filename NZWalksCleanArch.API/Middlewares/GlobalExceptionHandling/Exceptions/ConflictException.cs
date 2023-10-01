using System.Net;

namespace NZWalksCleanArch.API.Middlewares.GlobalExceptionHandling.Exceptions;

public class ConflictException : CustomException
{
    public ConflictException(string message)
        : base(message, null, HttpStatusCode.Conflict) { }
}
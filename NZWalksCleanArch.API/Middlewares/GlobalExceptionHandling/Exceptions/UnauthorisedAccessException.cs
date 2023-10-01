using System.Net;

namespace NZWalksCleanArch.API.Middlewares.GlobalExceptionHandling.Exceptions;

public class UnauthorisedAccessException : CustomException
{
    public UnauthorisedAccessException(string message) : base(message, null, HttpStatusCode.Unauthorized)
    {
    }
}

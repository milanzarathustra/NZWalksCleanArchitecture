using System.Net;

namespace NZWalksCleanArch.API.Middlewares.GlobalExceptionHandling.Exceptions;

public class NotImplementedException : CustomException
{
    public NotImplementedException(string message) : base(message, null, HttpStatusCode.NotImplemented)
    {
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Exceptios.HttpProblemDetails;

public class NotFoundProblemDetails:ProblemDetails
{
    public NotFoundProblemDetails(string detail)
    {
        Title = "Not Found Error";
        Detail = detail;
        Status = StatusCodes.Status404NotFound;
        Type = "http://tobeto.com/probs/notfound";
    }
}

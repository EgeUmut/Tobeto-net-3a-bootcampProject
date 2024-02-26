using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Core.Exceptios.Types.ValidationException;

namespace Core.Exceptios.HttpProblemDetails;

public class ValidationProblemDetails : ProblemDetails
{
    public IEnumerable<ValidationExceptionModel> Errors { get; set; }

    public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Title = "Validation Error";
        Detail = "One or more validation errors occured";
        Errors = errors;
        Status = StatusCodes.Status400BadRequest;
        Type = "http://tobeto.com/probs/Validation";
    }
}

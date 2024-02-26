using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Exceptios.Extensions;

public static class ProblemDetailsExtensions
{
    public static string AsJson<TProblemDetail>(this TProblemDetail problemDetails)
        where TProblemDetail : ProblemDetails => JsonSerializer.Serialize(problemDetails);
    //tüm problemdatails ler için çalışacak generic bir extension
}

using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptios.Extensions;

public static class ExceptionMiddleWareExtensions
{
    public static void ConfigureCustomExceptionMiddleWare(this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleWare>();
}

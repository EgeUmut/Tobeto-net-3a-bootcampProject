using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Text;

namespace Core.Aspects.Autofac.Logging;

public class LogAspect : MethodInterception
{
    private LoggerServiceBase _loggerServiceBase;
    private IHttpContextAccessor _contextAccessor;

    public LogAspect(Type loggerServiceBase)
    {
        if (loggerServiceBase.BaseType != typeof(LoggerServiceBase))
        {
            throw new Exception(AspectMessages.WrongLoggerType);
        }

        _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerServiceBase);
        //_contextAccessor = (IHttpContextAccessor)Activator.CreateInstance(typeof(HttpContextAccessor));
        _contextAccessor = ServiceTool.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
        //_contextAccessor = httpContextAccessor;
    }

    protected override void OnBefore(IInvocation invocation)
    {
        var logParameters = new List<LogParameter>();
        for (int i = 0; i < invocation.Arguments.Length; i++)
        {
            logParameters.Add(new LogParameter
            {
                Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                Value = invocation.Arguments[i],
                Type = invocation.Arguments[i].GetType().Name
            });
        }

        var logDetail = new LogDetail
        {
            MethodName = invocation.Method.Name,
            LogParameters = logParameters,
            User = _contextAccessor.HttpContext == null || _contextAccessor.HttpContext.User.Identity.Name == null
            ? "?" : _contextAccessor.HttpContext.User.Identity.Name,
            Response = _contextAccessor.HttpContext.Response.StatusCode.ToString()
            //Response = _contextAccessor.HttpContext.Response.Body.ToString()  
        };
        _loggerServiceBase.Info(JsonConvert.SerializeObject(logDetail));
    }

    //protected override void OnException(IInvocation invocation, Exception exception)
    //{
    //    var logParameters = new List<LogParameter>();
    //    for (int i = 0; i < invocation.Arguments.Length; i++)
    //    {
    //        logParameters.Add(new LogParameter
    //        {
    //            Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
    //            Value = invocation.Arguments[i],
    //            Type = invocation.Arguments[i].GetType().Name
    //        });
    //    }
    //    var logDetail = new LogDetail
    //    {
    //        MethodName = invocation.Method.Name,
    //        LogParameters = logParameters,
    //        User = _contextAccessor.HttpContext == null || _contextAccessor.HttpContext.User.Identity.Name == null
    //        ? "?" : _contextAccessor.HttpContext.User.Identity.Name,
    //        Response = exception.Message.ToString()
    //        //Response = _contextAccessor.HttpContext.Response.Body.ToString()  
    //    };
    //    _loggerServiceBase.Info(JsonConvert.SerializeObject(logDetail));
    //}

    //protected override void OnAfter(IInvocation invocation)
    //{
    //    var logParameters = new List<LogParameter>();
    //    for (int i = 0; i < invocation.Arguments.Length; i++)
    //    {
    //        logParameters.Add(new LogParameter
    //        {
    //            Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
    //            Value = invocation.Arguments[i],
    //            Type = invocation.Arguments[i].GetType().Name
    //        });
    //    }
    //    var logDetail = new LogDetail
    //    {
    //        MethodName = invocation.Method.Name,
    //        User = _contextAccessor.HttpContext == null || _contextAccessor.HttpContext.User.Identity.Name == null
    //            ? "?" : _contextAccessor.HttpContext.User.Identity.Name,
    //        Response = _contextAccessor.HttpContext.Response.StatusCode.ToString()
    //    };
    //    _loggerServiceBase.Info(JsonConvert.SerializeObject(logDetail));
    //}
}

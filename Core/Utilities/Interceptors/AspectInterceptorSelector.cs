using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
        var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
        classAttributes.AddRange(methodAttributes);
        //classAttributes.Add(new)

        return classAttributes.OrderBy(p=>p.Priority).ToArray();
    }
}

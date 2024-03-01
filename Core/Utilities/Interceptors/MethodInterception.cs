using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors;

public class MethodInterception : MethodInterceptionBaseAttribute
{
    protected virtual void OnBefore(IInvocation ınvocation)
    {

    }

    protected virtual void OnAfter(IInvocation ınvocation)
    {

    }

    protected virtual void onException(IInvocation ınvocation, System.Exception e)
    {

    }

    protected virtual void onSuccess(IInvocation ınvocation)
    {

    }

    public override void Intercept(IInvocation invocation)
    {
        var isSuccess = true;

        OnBefore(invocation);
        try
        {
            invocation.Proceed();
        }
        catch (Exception e)
        {

            isSuccess = false;
            onException(invocation, e);
            throw;
        }
        finally
        {
            if (isSuccess)
            {
                onSuccess(invocation);
            }
        }

        OnAfter(invocation);
    }
}

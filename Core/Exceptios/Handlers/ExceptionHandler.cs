using Core.Exceptios.Types;

namespace Core.Exceptios.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception) => exception switch
    {
        BusinessException businessException => HandleException(businessException),
        ValidationException validationException => HandleException(validationException),
        NotFoundException NotFoundException => HandleException(NotFoundException),
        AuthorizationException AuthorizationException => HandleException(AuthorizationException),
        _ => HandleException(exception)
    };

    protected abstract Task HandleException(BusinessException businessException);
    protected abstract Task HandleException(AuthorizationException authorizationException);
    protected abstract Task HandleException(NotFoundException notFoundException);
    protected abstract Task HandleException(ValidationException validationException);
    protected abstract Task HandleException(Exception exception);
}

namespace Core.Utilities.Results;

public class ErrorDataResult<T> : DataResult<T>
{
    //data true ve mesaj
    public ErrorDataResult(T data, string message) : base(data, false, message)
    {

    }
    //data ve true
    public ErrorDataResult(T data) : base(data, false)
    {

    }

    public ErrorDataResult(string message) : base(default, false, message)
    {

    }

    public ErrorDataResult() : base(default, false)
    {

    }
}

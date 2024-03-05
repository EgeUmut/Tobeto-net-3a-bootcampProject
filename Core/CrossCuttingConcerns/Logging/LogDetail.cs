namespace Core.CrossCuttingConcerns.Logging;

public  class LogDetail
{
    public string MethodName { get; set; }
    public string User { get; set; }
    public List<LogParameter> LogParameters { get; set; }
    public string Response { get; set; }

    public LogDetail(string methodName, string user, List<LogParameter> logParameters, string response) : this()
    {
        MethodName = methodName;
        User = user;
        LogParameters = logParameters;
        Response = response;
    }

    public LogDetail(string methodName, string user, List<LogParameter> logParameters) : this()
    {
        MethodName = methodName;
        User = user;
        LogParameters = logParameters;
    }

    public LogDetail()
    {
        
    }
}

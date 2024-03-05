using Serilog;

namespace Core.CrossCuttingConcerns.Logging.SeriLog;

public abstract class LoggerServiceBase
{
    protected static ILogger Logger { get; set; }

    public void Verbose(string message) => Logger.Verbose(message);
    public void Fatal(string message) => Logger.Fatal(message);
    public void Info(string message)
    {
        if (Logger != null)
        {
            Logger.Information(message);
        }
        else
        {
            // Logger null ise yapılacak işlemler
        }
    } //=> Logger.Information(message);
    public void Warning(string message) => Logger.Warning(message);
    public void Debug(string message) => Logger.Debug(message);
    public void Error(string message) => Logger.Error(message);
}

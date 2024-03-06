using Core.CrossCuttingConcerns.Logging.SeriLog.ConfigurationModels;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;

public class MssqlLogger:LoggerServiceBase
{
    private IConfiguration _configuration;

    //public MssqlLogger()
    //{

    //}
    //public MssqlLogger(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //    MssqlConfiguration logConfiguration = configuration.GetSection("SerilogConfigurations:MssqlConfiguration").Get<MssqlConfiguration>() ?? throw new Exception("");
    //    MSSqlServerSinkOptions sinkOptions = new() { TableName = logConfiguration.TableName , AutoCreateSqlDatabase = logConfiguration.AutoCreatedSqlTable};
    //    ColumnOptions columnOptions = new();
    //    Logger seriLogConfig = new LoggerConfiguration().WriteTo.MSSqlServer(logConfiguration.ConnectionString, sinkOptions, columnOptions:columnOptions).CreateLogger();
    //    Logger = seriLogConfig;
    //}

    public MssqlLogger()
    {
        var configuration = ServiceTool.ServiceProvider.GetRequiredService<IConfiguration>();
        MssqlConfiguration logConfiguration = configuration.GetSection("SerilogConfigurations:MssqlConfiguration")
           .Get<MssqlConfiguration>() ?? throw new Exception("");

        MSSqlServerSinkOptions sinkOptions = new()
        { TableName = logConfiguration.TableName, AutoCreateSqlTable = logConfiguration.AutoCreatedSqlTable };

        ColumnOptions columnOptions = new();
        global::Serilog.Core.Logger serilogConfig = new LoggerConfiguration().WriteTo
            .MSSqlServer(connectionString: logConfiguration.ConnectionString, sinkOptions: sinkOptions, columnOptions: columnOptions).CreateLogger();
        Logger = serilogConfig;

        //MSSqlServerSinkOptions sinkOptions = new()
        //{ TableName = "Logs", AutoCreateSqlTable = true };

        //ColumnOptions columnOptions = new();
        //global::Serilog.Core.Logger serilogConfig = new LoggerConfiguration().WriteTo
        //    .MSSqlServer("server=(localdb)\\MSSQLLocalDB;database=TobetoBootCampProjectDb;trusted_connection=true", sinkOptions, columnOptions: columnOptions).CreateLogger();
        //Logger = serilogConfig;


    }
}

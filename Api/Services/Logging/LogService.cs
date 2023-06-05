using NLog;

namespace Api.Services.Logging;

public class LogService : ILogService
{
    private static readonly NLog.ILogger Logger = LogManager.GetCurrentClassLogger();

    public LogService()
    {
    }

    public void Info(string message) => Logger.Info(message);

    public void Warn(string message) => Logger.Warn(message);

    public void Debug(string message) => Logger.Debug(message);

    public void Error(string message) => Logger.Error(message);
}
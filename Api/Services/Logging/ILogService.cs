namespace Api.Services.Logging;

public interface ILogService
{
    void Info(string message);

    void Warn(string message);

    void Debug(string message);

    void Error(string message);
}

using Microsoft.Extensions.Logging;

namespace LoggerExtensionDelegate;

public static class LoggerExtension
{
    private static readonly Action<ILogger, string, Exception> FastLoggerMessageValue =
        LoggerMessage.Define<string>(
            LogLevel.Information,
            eventId: new EventId(id: 1, name: "ERROR"),
            formatString: "Message: {Message}");

    public static void FastLoggerMessage(ILogger? logger, string message, Exception exception)
    {
        if (logger != null)
        {
            FastLoggerMessageValue(logger, message, exception);
        }
    }
}

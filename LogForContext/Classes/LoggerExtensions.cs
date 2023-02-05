using System.Runtime.CompilerServices;
using Serilog;

namespace LogForContext.Classes;

public static class LoggerExtensions
{
    public static ILogger Here(
        this ILogger logger, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0) => logger
            .ForContext("MemberName", memberName)
            .ForContext("FilePath", sourceFilePath)
            .ForContext("LineNumber", sourceLineNumber);
}
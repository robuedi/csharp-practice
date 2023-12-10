using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

enum LogLevel 
{
    Unknown,
    Trace,
    Debug,
    Info = 4,
    Warning,
    Error,
    Fatal = 42
}

static class LogLine
{
    private static Dictionary<string, LogLevel> logShorts = new Dictionary<string, LogLevel>{
        {"TRC", LogLevel.Trace},
        {"DBG", LogLevel.Debug},
        {"INF", LogLevel.Info},
        {"WRN", LogLevel.Warning},
        {"ERR", LogLevel.Error},
        {"FTL", LogLevel.Fatal},
    };

    public static LogLevel ParseLogLevel(string logLine)
    {
        Match match = Regex.Match(logLine, @"^\[([A-Z]{3})\]\:.*", RegexOptions.IgnoreCase);
        if (!match.Success)
            return LogLevel.Unknown;
        
        //output the value
        LogLevel value;
        bool hasValue = logShorts.TryGetValue(match.Groups[1].Value, out value);
        if(hasValue)
            return value;
          
        return LogLevel.Unknown;
    }

    public static string OutputForShortLog(LogLevel LogLevel, string message) => $"{Convert.ChangeType(LogLevel, LogLevel.GetTypeCode())}:{message}";
}

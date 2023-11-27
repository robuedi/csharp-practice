using System;
using System.Text.RegularExpressions;

static class LogLine
{
    private static string _errorCodeRegex = @"^\[[A-Z]+\]:(\s){0,}";
    private static string _errorCodeLevelRegex = @"[A-Z]+";

    public static string Message(string logLine) => Regex.Replace(logLine, _errorCodeRegex, "").Trim();
    
    public static string LogLevel(string logLine)
    {
        Match errorText = Regex.Match(logLine, _errorCodeRegex);
        if(!errorText.Success)
        {
            throw new ArgumentException("Invalid error text, missing error text");
        }

        Match errorCode = Regex.Match(errorText.Value, _errorCodeLevelRegex);
        if(!errorCode.Success)
        {
            throw new ArgumentException("Invalid error code, missing error code");
        }

        return errorCode.Value.ToLower();
    }

    public static string Reformat(string logLine)
    {
        string errorMessage = LogLine.Message(logLine);
        string errorLevel = LogLine.LogLevel(logLine);

        if(errorMessage == "" || errorLevel == "")
        {
            throw new ArgumentException("Invalid error code, missing error message or error level");
        }

        return $"{errorMessage} ({errorLevel})";
    }
}

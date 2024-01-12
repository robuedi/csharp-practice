using System;
using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text) => Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)]");

    public string[] SplitLogLine(string text) => Regex.Split(text, @"<[=\-^*]{1,}>");

    public int CountQuotedPasswords(string lines) => Regex.Count(lines, @""".*(?i)password.*""");

    public string RemoveEndOfLineText(string line) => Regex.Replace(line, @"end-of-line\d*", "");

    public string[] ListLinesWithPasswords(string[] lines)
    {
        Regex passRegex = new Regex(@"((?i)password[\S]{1,})");

        for (int i = 0; i < lines.Length; i++) 
        {
            Match passMatch = passRegex.Match(lines[i]);
            if (passMatch.Success)
            {
                lines[i] = $"{passMatch.Value}: {lines[i]}";
                continue;
            }

            lines[i] = $"--------: {lines[i]}";
        }

        return lines;
    }
}

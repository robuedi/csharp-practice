using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string logTxt, string delimiter) => logTxt[(logTxt.IndexOf(delimiter)+delimiter.Length)..];

    public static string SubstringBetween(this string logTxt, string str1, string str2) =>  logTxt[(logTxt.IndexOf(str1)+str1.Length)..logTxt.IndexOf(str2)];
    
    public static string Message(this string logTxt) => logTxt.SubstringAfter(": ");

    public static string LogLevel(this string logTxt) => logTxt.SubstringBetween("[", "]");
}
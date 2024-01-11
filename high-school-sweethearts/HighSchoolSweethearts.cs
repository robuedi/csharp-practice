using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    private const string bannerTop = @"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
";
    private const string bannerBottom = @"
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";

    public static string DisplaySingleLine(string studentA, string studentB) => $"{studentA, (61 - 3) / 2} ♡ {studentB, -((61 - 3) / 2)}";
    
    public static string DisplayBanner(string studentA, string studentB) => $"{bannerTop}**     {studentA} +  {studentB}    **{bannerBottom}";

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours) => $"{studentA} and {studentB} have been dating since {start:dd.MM.yyyy} - that's {hours.ToString("N2", new CultureInfo("de-DE"))} hours";
}

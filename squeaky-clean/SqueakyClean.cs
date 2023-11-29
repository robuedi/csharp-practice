using System;
using System.Text.RegularExpressions;

public static class Identifier
{
    public static string Clean(string identifier) => identifier.Replace(' ', '_').Replace("\0", "CTRL").CamelCase().CleanSpecialChars().CleanGreekLowcase();

    private static string CamelCase(this string txt) => Regex.Replace(txt, @"-(\p{L})", m => $"{m.Groups[1].Value.ToUpper()}");

    private static string CleanSpecialChars(this string txt) => Regex.Replace(txt, @"[^\p{L}_]", "");

    private static string CleanGreekLowcase(this string txt) => Regex.Replace(txt, @"[α-ω]+", "");    
}

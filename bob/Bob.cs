using System;
using System.Text.RegularExpressions;

public static class Bob
{
    public static string Response(string statement)
    {
        //check for silence
        Match isSilence = Regex.Match(statement, @"^(\s){0,}$");
        if(isSilence.Success)
        {
            return "Fine. Be that way!";
        }

        Match isYelling = Regex.Match(statement, @"^[^a-z]*[A-Z][^a-z]*$");
        bool isQuestioning = statement.Trim().EndsWith("?");
        //check yelling & questiong
        if(isYelling.Success && isQuestioning)
        {
            return "Calm down, I know what I'm doing!";
        }

        //check yelling
        if(isYelling.Success)
        {
            return "Whoa, chill out!";
        }

        // check questioning
        if(isQuestioning)
        {
            return "Sure.";
        }

        //default
        return "Whatever.";
    }
}
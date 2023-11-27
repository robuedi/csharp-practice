using System;
using System.Linq;
using System.Collections.Generic;

public static class PigLatin
{
    private static string[] vowels = new string[]{"a", "e", "i", "o", "u", "xr", "yt"};

    public static string Translate(string word)
    {
        string[] words = word.Split(' ');

        List<string> processedWords = new List<string> {};
        foreach (string wrd in words)
        {
            if(wrd.begingWithVowel())
            {
                processedWords.Add($"{wrd}ay");
                continue;
            }

            processedWords.Add(wrd.makeConsonWord());
        }

        return  String.Join(" ", processedWords);
    }

    private static bool begingWithVowel(this string word) 
    {
        string wordLower = word.ToLower();
        return vowels.Any(v => wordLower.StartsWith(v));
    }

    private static string makeConsonWord(this string word) 
    {
        string cons = "";
        foreach (char i in word) 
        {
            if(!i.checkValidConsone(word, cons))
            {
                break;
            }

            cons += i;
        } 

        return $"{word[cons.Length..]}{cons}ay";
    }

    private static bool checkValidConsone(this char consLetter, string word, string currentCons)
    {
        String letter = consLetter.ToString().ToLower(); 

        if(letter == "y" && currentCons != "" && word.Length == 2)
        {
            return false;
        }

        if(vowels.Any(v => word[currentCons.Length..].StartsWith(v)) && !(letter == "u" && currentCons.EndsWith("q")))
        {
            return false;
        }

        return true;
    }
}
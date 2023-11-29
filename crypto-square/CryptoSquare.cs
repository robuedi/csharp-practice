using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        return Regex.Replace(plaintext, @"\W", "").ToLower();
    }
    
    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        string normalizedTxt = CryptoSquare.NormalizedPlaintext(plaintext);
        
        (int columns, int rows) = normalizedTxt.TxtSquareSizes();
        
        //prepare text
        int neededLenght = rows*columns;
        int txtLength = normalizedTxt.Length;
        if(txtLength < neededLenght)
        {
            normalizedTxt = $"{normalizedTxt}{new string(' ', neededLenght-txtLength)}";
        }
        
        //cut to chunks and return
        return Enumerable.Range(0, rows)
                .Select(i => normalizedTxt.Substring(i *columns, columns));
    }

    public static string Encoded(string plaintext)
    {
        return CryptoSquare.Ciphertext(plaintext).Replace(" ", "");
    }

    public static string Ciphertext(string plaintext)
    {
        IEnumerable<string> segments = CryptoSquare.PlaintextSegments(plaintext);
        (int columns, int rows) = String.Join("", segments).TxtSquareSizes();

        //reshaping the segments
        IEnumerable<string> secondCoded = Enumerable.Range(0, columns)
                .Select(i => String.Join("", segments.Select(txt => txt[i])));

        return String.Join(" ", secondCoded);
    }

    private static (int columns, int rows) TxtSquareSizes(this string plaintext)
    {
        int txtLength = plaintext.Length;
        double sqrtRoot  = Math.Sqrt(txtLength);
        int floorRoot = (int)Math.Floor(sqrtRoot);
        double floorRootHalfPoint = floorRoot+0.5;
        
        //after testing multiple value i saw this pattern for columns and rows based on square root
        int rows = 0;
        int columns = 0;
        if(floorRoot == sqrtRoot)
        {
            rows = floorRoot;
            columns = floorRoot;
        }
        else if(sqrtRoot < floorRootHalfPoint)
        {
            rows = floorRoot;
            columns = floorRoot+1;
        }
        else
        {
            rows = floorRoot+1;
            columns = floorRoot+1;
        }

        return (columns, rows);
    }
}
using System;

public static class SimpleCalculator
{
    public static string Calculate(int a, int b, string x) => x switch { 
        "+" => $"{a} + {b} = {a+b}",
        "*" => $"{a} * {b} = {a*b}",
        "/" => b == 0 ? "Division by zero is not allowed." :  $"{a} / {b} = {a/b}",
        null => throw new ArgumentNullException(),
        "" => throw new ArgumentException(),
        _ => throw new ArgumentOutOfRangeException()
    };
}

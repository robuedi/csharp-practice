using System;
using System.Linq;
using System.Collections;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max) => (int)Math.Pow(Enumerable.Range(1, max).Aggregate(0, (acc, x) => acc + x), 2);

    public static int CalculateSumOfSquares(int max) => Enumerable.Range(1, max).Aggregate(0, (acc, x) => acc + x*x);

    public static int CalculateDifferenceOfSquares(int max) => DifferenceOfSquares.CalculateSquareOfSum(max)-DifferenceOfSquares.CalculateSumOfSquares(max);
}
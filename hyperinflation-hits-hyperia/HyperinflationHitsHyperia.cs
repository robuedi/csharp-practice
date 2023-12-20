using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try{
            return (checked(@base*multiplier)).ToString();
        }
        catch(OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float gdp = @base*multiplier;

        return double.IsInfinity(gdp) ? "*** Too Big ***" : gdp.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try{
            return (checked(salaryBase*multiplier)).ToString();
        }
        catch(OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}

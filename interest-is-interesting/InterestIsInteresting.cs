using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if(balance < 0)
        {
            return 3.213f;
        }
        else if(balance < 1000)
        {
            return 0.5f;
        }
        else if(balance < 5000)
        {
            return 1.621f;
        }
          
        return 2.475f;
    }

    public static decimal Interest(decimal balance)
    {
        return ((decimal)SavingsAccount.InterestRate(balance)/100)*balance;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return SavingsAccount.Interest(balance)+balance;
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        decimal finalBalance = balance;
        int years = 0;
        while(finalBalance<targetBalance){
            finalBalance = SavingsAccount.AnnualBalanceUpdate(finalBalance);
            years++;
        }
        return years;
    }
}

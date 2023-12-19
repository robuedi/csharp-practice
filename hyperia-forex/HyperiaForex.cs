using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public decimal Amount {get {return amount;}}
    public string Currency {get {return currency;}}

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.Currency != b.Currency)
            throw new ArgumentException();

        return a.amount == b.amount;
    }

    public static bool operator !=(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.Currency != b.Currency)
            throw new ArgumentException();

        return a.amount != b.amount;
    }

    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.Currency != b.Currency)
            throw new ArgumentException();

        return a.amount > b.amount;
    }

    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.Currency != b.Currency)
            throw new ArgumentException();

        return a.amount < b.amount;
    }

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.Currency != b.Currency)
            throw new ArgumentException();

        return new CurrencyAmount(a.amount - b.amount, a.Currency);
    }

    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.Currency != b.Currency)
            throw new ArgumentException();

        return new CurrencyAmount(a.amount + b.amount, a.Currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.Currency != b.Currency)
            throw new ArgumentException();

        return new CurrencyAmount(a.amount * b.amount, a.Currency);
    }

    public static CurrencyAmount operator *(decimal a, CurrencyAmount b) => new CurrencyAmount(a * b.amount, b.Currency);
    public static CurrencyAmount operator *(CurrencyAmount a, decimal b) => new CurrencyAmount(a.amount * b, a.Currency);

    public static CurrencyAmount operator /(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.Currency != b.Currency)
            throw new ArgumentException();

        return new CurrencyAmount(a.amount / b.amount, a.Currency);
    }

    public static CurrencyAmount operator /(decimal a, CurrencyAmount b) => new CurrencyAmount(a / b.amount, b.Currency);
    public static CurrencyAmount operator /(CurrencyAmount a, decimal b) => new CurrencyAmount(a.amount / b, a.Currency);


    public static implicit operator double(CurrencyAmount a) => (double)a.amount;
    public static implicit operator decimal(CurrencyAmount a) => a.amount;
}

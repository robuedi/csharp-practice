using System;

class WeighingMachine
{
    public int Precision {get; private set;}

    private double weight;
    public double Weight {
        get {return weight;}
        set {
            if(value < 0)
                throw new ArgumentOutOfRangeException();

            weight = value;
        }
    }
    public double TareAdjustment {get;set;} = 5;
    public string DisplayWeight {
        get {return $"{(Weight-TareAdjustment).ToString("F" + Precision)} kg";}
    }

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}

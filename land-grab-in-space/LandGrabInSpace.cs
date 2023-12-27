using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public int GetBigVal() => X > Y ? X : Y;
}

public struct Plot : IComparable
{
    public Coord A {get;set;}
    public Coord B {get;set;}
    public Coord C {get;set;}
    public Coord D {get;set;}

    public Plot(Coord a, Coord b, Coord c, Coord d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    public int CompareTo(object obj) {
        if (obj == null) return 1;

        Plot plot = (Plot)obj;
        if(this.GetBiggestCord() > plot.GetBiggestCord())
            return 1;
        else if(this.GetBiggestCord() < plot.GetBiggestCord())
            return -1;

        return 0;
    }

    public int GetBiggestCord()
    {
        List<int> cordsBig = new(){A.GetBigVal(), B.GetBigVal(), C.GetBigVal(), D.GetBigVal()};
        cordsBig.Sort();
        return cordsBig.Last();
    }

}


public class ClaimsHandler
{
    private List<Plot> plots = new();

    public void StakeClaim(Plot plot)
    {
        this.plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot) => this.plots.Contains(plot);

    public bool IsLastClaim(Plot plot) => plot.Equals(this.plots.Last());

    public Plot GetClaimWithLongestSide()
    {
        this.plots.Sort();
        return this.plots.Last();
    }
}

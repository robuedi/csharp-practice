using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
       if(Darts.insideRange(x,y,1))
       {
            return 10;
       }

       if(Darts.insideRange(x,y,5))
       {
            return 5;
       }

       if(Darts.insideRange(x,y,10))
       {
            return 1;
       }

       return 0;
    }

    private static bool insideRange(double x, double y, int radius)
    {
       if((x*x)+(y*y) <= radius*radius)
       {
            return true;
       }

       return false;
    }
}

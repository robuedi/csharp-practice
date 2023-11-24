using System;

static class AssemblyLine
{
    public static int CarsPerHour {get;set;} = 221;

    public static double SuccessRate(int speed)
    {
        if(speed < 1){
            return 0;
        }
        else if(speed <= 4){
            return 1;
        }
        else if(speed <= 8){
            return 0.9;
        }
        else if(speed <= 9){
            return 0.8;
        }

        return 0.77;
    }
    
    public static double ProductionRatePerHour(int speed) => speed*AssemblyLine.CarsPerHour*AssemblyLine.SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) => (int)AssemblyLine.ProductionRatePerHour(speed) / 60;
}

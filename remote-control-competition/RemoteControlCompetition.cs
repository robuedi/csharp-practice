using System;
using System.Collections.Generic;

public interface IRemoteControlCar
{
    int DistanceTravelled { get; }

    void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(object obj) 
    {
        ProductionRemoteControlCar car = obj as ProductionRemoteControlCar;
        if (car == null) return 1;

        if(car.NumberOfVictories > NumberOfVictories)
            return -1;
        else if(car.NumberOfVictories < NumberOfVictories)
            return 1;

        return 0;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        var carList = new List<ProductionRemoteControlCar>{prc1, prc2};
        carList.Sort();
        return carList;
    }
}

using System;
using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;
    public static int[] LastWeekCounts = {0, 2, 5, 3, 7, 8, 4};

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => LastWeekCounts;

    public int Today() => birdsPerDay.Last();

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length-1] = birdsPerDay.Last()+1;
    }

    public bool HasDayWithoutBirds() => birdsPerDay.Any(day => day == 0);

    public int CountForFirstDays(int numberOfDays)
    {
        int sum = 0;
        for(int i = 0; i < numberOfDays && i < birdsPerDay.Length; i++)
        {
            sum += birdsPerDay[i];
        }
        return sum;
    }

    public int BusyDays() => birdsPerDay.Where(i => i >= 5).Count();
}

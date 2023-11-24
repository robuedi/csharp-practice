class Lasagna
{
    protected int Minutes {get;set;} = 40;
    protected int MinutesPerLayer {get;set;} = 2;

    public int ExpectedMinutesInOven() => Minutes;

    public int RemainingMinutesInOven(int passedMinutes) => Minutes-passedMinutes;

    public int PreparationTimeInMinutes(int nrLayers) => MinutesPerLayer*nrLayers;

    public int ElapsedTimeInMinutes(int nrLayers, int ovenTime) => (MinutesPerLayer*nrLayers)+ovenTime;
}

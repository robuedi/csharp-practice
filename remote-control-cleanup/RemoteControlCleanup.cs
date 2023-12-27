public class RemoteControlCar
{
    public TelemetryCar Telemetry {get;}

    public RemoteControlCar()
    {
        Telemetry = new TelemetryCar(this);
    }

    public class TelemetryCar 
    {
        private RemoteControlCar _car;

        public TelemetryCar(RemoteControlCar car)
        {
            _car = car;
        }

        public void Calibrate()
        {

        }

        public bool SelfTest()
        {
            return true;
        }

        public void ShowSponsor(string sponsorName)
        {
            _car.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            SetSpeed(new Speed(amount, speedUnits));
        }

        private void SetSponsor(string sponsor) => _car.CurrentSponsor = sponsor;
        private void SetSpeed(Speed speed) => _car.currentSpeed = speed;
    }


    public string CurrentSponsor { get; private set; }

    private Speed currentSpeed;

    public string GetSpeed()
    {
        return currentSpeed.ToString();
    }

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;

    }

    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }
}


public struct Speed
{
    public decimal Amount { get; }
    public SpeedUnits SpeedUnits { get; }

    public Speed(decimal amount, SpeedUnits speedUnits)
    {
        Amount = amount;
        SpeedUnits = speedUnits;
    }

    public override string ToString()
    {
        string unitsString = "meters per second";
        if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
        {
            unitsString = "centimeters per second";
        }

        return Amount + " " + unitsString;
    }
}

public enum SpeedUnits
{
    MetersPerSecond,
    CentimetersPerSecond
}


using System;

class RemoteControlCar
{
    private int _speed;
    private int _batteryDrain;
    private int _distanceDriven;
    private int _battery = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => _batteryDrain > _battery ? true : false;

    public int DistanceDriven() => _distanceDriven;

    public void Drive()
    {
        if(_batteryDrain > _battery)
        {
            _battery = 0;
            return;
        }
           
        _distanceDriven += _speed;
        _battery -= _batteryDrain;
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);

    public double MaximumRange() => _batteryDrain != 0 ? (_battery/_batteryDrain)*_speed : 0;
}

class RaceTrack
{
    private int _distance;

    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car) => car.MaximumRange() >= _distance;
}

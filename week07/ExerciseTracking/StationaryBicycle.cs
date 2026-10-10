using System;

public class StationaryBicycle : Activity
{
    private double _speed;

    public StationaryBicycle(string date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override string GetActivityName()
    {
        return "Stationary Bicycle";
    }

    public override double GetDistance()
    {
        return (_speed * GetMinutes()) / 60.0;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60.0 / _speed;
    }
}

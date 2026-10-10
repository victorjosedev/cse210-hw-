using System;
using System.Globalization;

public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public virtual string GetActivityName()
    {
        return GetType().Name;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "{0} {1} ({2} min): Distance {3:0.0} km, Speed: {4:0.0} kph, Pace: {5:0.00} min per km",
            _date,
            GetActivityName(),
            _minutes,
            GetDistance(),
            GetSpeed(),
            GetPace()
        );
    }
}

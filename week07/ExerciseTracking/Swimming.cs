using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50.0 / 1000) * 0.62;
    }

    public override double GetSpeed()
    {
        if (GetMinutes() == 0)
        {
            return 0;
        }

        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        if (GetDistance() == 0)
        {
            return 0;
        }

        return GetMinutes() / GetDistance();
    }
}

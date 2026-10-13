using System;

public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        if (GetMinutes() == 0)
        {
            return 0;
        }

        return (_distance / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        if (_distance == 0)
        {
            return 0;
        }

        return GetMinutes() / _distance;
    }
}

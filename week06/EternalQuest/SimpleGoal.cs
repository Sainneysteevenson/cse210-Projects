using System.Globalization;

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : this(name, description, points, false)
    {
    }

    internal SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override bool IsComplete => _isComplete;

    public override int RecordProgress()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return Points;
    }

    protected override string GetProgressDescription()
    {
        return $"{Points} points";
    }

    public override string ToSaveString()
    {
        return Serialize("SIMPLE", _isComplete.ToString(CultureInfo.InvariantCulture));
    }
}

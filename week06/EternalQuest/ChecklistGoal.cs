using System.Globalization;

class ChecklistGoal : Goal
{
    private readonly int _targetCount;
    private readonly int _bonus;
    private int _currentCount;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonus)
        : this(name, description, points, targetCount, 0, bonus)
    {
    }

    internal ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int currentCount,
        int bonus)
        : base(name, description, points)
    {
        if (targetCount <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(targetCount),
                "The checklist target must be greater than zero.");
        }

        if (currentCount < 0 || currentCount > targetCount)
        {
            throw new ArgumentOutOfRangeException(
                nameof(currentCount),
                "Checklist progress must be between zero and its target.");
        }

        if (bonus < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bonus), "The bonus cannot be negative.");
        }

        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonus = bonus;
    }

    public override bool IsComplete => _currentCount >= _targetCount;

    public override int RecordProgress()
    {
        if (IsComplete)
        {
            return 0;
        }

        _currentCount++;
        return IsComplete ? checked(Points + _bonus) : Points;
    }

    protected override string GetProgressDescription()
    {
        return $"{_currentCount}/{_targetCount} completed, {Points} points each, {_bonus} point bonus";
    }

    public override string ToSaveString()
    {
        return Serialize(
            "CHECKLIST",
            _targetCount.ToString(CultureInfo.InvariantCulture),
            _currentCount.ToString(CultureInfo.InvariantCulture),
            _bonus.ToString(CultureInfo.InvariantCulture));
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override bool IsComplete => false;

    public override int RecordProgress()
    {
        return Points;
    }

    protected override string GetProgressDescription()
    {
        return $"{Points} points each time";
    }

    public override string ToSaveString()
    {
        return Serialize("ETERNAL");
    }
}

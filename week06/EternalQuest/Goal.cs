using System.Globalization;
using System.Text;

abstract class Goal
{
    private readonly string _name;
    private readonly string _description;
    private readonly int _points;

    protected Goal(string name, string description, int points)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("A goal name is required.", nameof(name));
        }

        if (points <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points), "Points must be greater than zero.");
        }

        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;
    public abstract bool IsComplete { get; }

    public abstract int RecordProgress();
    protected abstract string GetProgressDescription();
    public abstract string ToSaveString();

    public string GetDetailsString()
    {
        string status = IsComplete ? "X" : " ";
        return $"[{status}] {_name} ({_description}) -- {GetProgressDescription()}";
    }

    protected string Serialize(string goalType, params string[] additionalFields)
    {
        var fields = new List<string>
        {
            goalType,
            Encode(_name),
            Encode(_description),
            _points.ToString(CultureInfo.InvariantCulture)
        };
        fields.AddRange(additionalFields);
        return string.Join("|", fields);
    }

    public static Goal FromSaveString(string saveString)
    {
        string[] fields = saveString.Split('|');
        if (fields.Length < 4)
        {
            throw new FormatException("A goal entry has too few fields.");
        }

        string name = Decode(fields[1]);
        string description = Decode(fields[2]);
        int points = ParseInt(fields[3], "goal points");

        return fields[0] switch
        {
            "SIMPLE" when fields.Length == 5 && bool.TryParse(fields[4], out bool isComplete) =>
                new SimpleGoal(name, description, points, isComplete),
            "ETERNAL" when fields.Length == 4 =>
                new EternalGoal(name, description, points),
            "CHECKLIST" when fields.Length == 7 =>
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    ParseInt(fields[4], "checklist target"),
                    ParseInt(fields[5], "checklist progress"),
                    ParseInt(fields[6], "checklist bonus")),
            "SIMPLE" => throw new FormatException("A simple goal entry is malformed."),
            "ETERNAL" => throw new FormatException("An eternal goal entry is malformed."),
            "CHECKLIST" => throw new FormatException("A checklist goal entry is malformed."),
            _ => throw new FormatException($"Unknown goal type '{fields[0]}'.")
        };
    }

    protected static string Encode(string value)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
    }

    private static string Decode(string value)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }

    private static int ParseInt(string value, string fieldName)
    {
        if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result))
        {
            throw new FormatException($"The {fieldName} value is invalid.");
        }

        return result;
    }
}

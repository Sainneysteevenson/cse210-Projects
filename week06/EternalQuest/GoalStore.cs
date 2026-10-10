using System.Globalization;
using System.Text;

static class GoalStore
{
    private const string FileHeader = "ETERNAL_QUEST|1";

    public static void Save(string path, long score, IReadOnlyList<Goal> goals)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(score), "The score cannot be negative.");
        }

        var lines = new List<string>
        {
            FileHeader,
            score.ToString(CultureInfo.InvariantCulture)
        };
        lines.AddRange(goals.Select(goal => goal.ToSaveString()));
        File.WriteAllLines(path, lines, Encoding.UTF8);
    }

    public static (List<Goal> Goals, long Score) Load(string path)
    {
        string[] lines = File.ReadAllLines(path, Encoding.UTF8);
        if (lines.Length < 2 || lines[0] != FileHeader)
        {
            throw new FormatException("The file is not a supported Eternal Quest save file.");
        }

        if (!long.TryParse(lines[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out long score)
            || score < 0)
        {
            throw new FormatException("The saved score is invalid.");
        }

        var goals = new List<Goal>();
        for (int index = 2; index < lines.Length; index++)
        {
            if (string.IsNullOrWhiteSpace(lines[index]))
            {
                continue;
            }

            try
            {
                goals.Add(Goal.FromSaveString(lines[index]));
            }
            catch (FormatException exception)
            {
                throw new FormatException($"Could not read goal on line {index + 1}: {exception.Message}", exception);
            }
        }

        return (goals, score);
    }
}

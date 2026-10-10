using System.Globalization;

class Program
{
    private const string DefaultSaveFile = "eternalQuest.txt";

    static void Main(string[] args)
    {
        var goals = new List<Goal>();
        long score = 0;
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine();
            Console.WriteLine($"You have {score} points ({GetRank(score)}).");
            Console.WriteLine("Menu options:");
            Console.WriteLine("  1. Create a new goal");
            Console.WriteLine("  2. List goals");
            Console.WriteLine("  3. Record goal progress");
            Console.WriteLine("  4. Show score and rank");
            Console.WriteLine("  5. Save goals");
            Console.WriteLine("  6. Load goals");
            Console.WriteLine("  7. Quit");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine();
            if (choice == null)
            {
                break;
            }

            switch (choice.Trim())
            {
                case "1":
                    CreateGoal(goals);
                    break;
                case "2":
                    DisplayGoals(goals);
                    break;
                case "3":
                    RecordProgress(goals, ref score);
                    break;
                case "4":
                    DisplayScore(score);
                    break;
                case "5":
                    SaveProgress(goals, score);
                    break;
                case "6":
                    LoadProgress(ref goals, ref score);
                    break;
                case "7":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Please select a number from 1 to 7.");
                    break;
            }
        }

        Console.WriteLine("Keep going on your eternal quest!");
    }

    private static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("Goal types: 1. Simple  2. Eternal  3. Checklist");
        string? type = ReadInput("Choose a type (or press Enter to cancel): ");
        if (type == null || string.IsNullOrWhiteSpace(type))
        {
            return;
        }

        string? name = ReadInput("Goal name (or press Enter to cancel): ");
        if (string.IsNullOrWhiteSpace(name))
        {
            return;
        }

        string? description = ReadInput("Description: ");
        if (description == null)
        {
            return;
        }

        int? points = ReadPositiveInt("Points for each completion: ");
        if (points == null)
        {
            return;
        }

        Goal? goal;
        switch (type.Trim())
        {
            case "1":
                goal = new SimpleGoal(name.Trim(), description.Trim(), points.Value);
                break;
            case "2":
                goal = new EternalGoal(name.Trim(), description.Trim(), points.Value);
                break;
            case "3":
                int? target = ReadPositiveInt("How many times must this goal be completed? ");
                if (target == null)
                {
                    return;
                }

                int? bonus = ReadNonNegativeInt("Bonus points when the goal is finished: ");
                if (bonus == null)
                {
                    return;
                }

                goal = new ChecklistGoal(
                    name.Trim(),
                    description.Trim(),
                    points.Value,
                    target.Value,
                    bonus.Value);
                break;
            default:
                Console.WriteLine("That is not a valid goal type.");
                return;
        }

        goals.Add(goal);
        Console.WriteLine($"Added goal: {goal.Name}");
    }

    private static void DisplayGoals(IReadOnlyList<Goal> goals)
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("You have not created any goals yet.");
            return;
        }

        Console.WriteLine("Your goals:");
        for (int index = 0; index < goals.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {goals[index].GetDetailsString()}");
        }
    }

    private static void RecordProgress(IReadOnlyList<Goal> goals, ref long score)
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording progress.");
            return;
        }

        DisplayGoals(goals);
        int? goalNumber = ReadPositiveInt("Which goal did you accomplish? ");
        if (goalNumber == null)
        {
            return;
        }

        if (goalNumber > goals.Count)
        {
            Console.WriteLine("There is no goal with that number.");
            return;
        }

        Goal goal = goals[goalNumber.Value - 1];
        bool wasComplete = goal.IsComplete;
        int pointsEarned = goal.RecordProgress();
        if (pointsEarned == 0)
        {
            Console.WriteLine("That goal is already complete and cannot earn more points.");
            return;
        }

        score = checked(score + pointsEarned);
        Console.WriteLine($"Progress recorded for \"{goal.Name}\". You earned {pointsEarned} points.");
        if (!wasComplete && goal.IsComplete)
        {
            Console.WriteLine("Goal completed!");
        }
    }

    private static void DisplayScore(long score)
    {
        Console.WriteLine($"Total points: {score}");
        Console.WriteLine($"Quest rank: {GetRank(score)}");
    }

    // Creative extension: lifetime points unlock quest ranks, which are restored automatically with the score.
    private static string GetRank(long score)
    {
        return score switch
        {
            >= 1000 => "Legend",
            >= 500 => "Champion",
            >= 100 => "Apprentice",
            _ => "Novice"
        };
    }

    private static void SaveProgress(IReadOnlyList<Goal> goals, long score)
    {
        string path = GetSavePath();
        try
        {
            GoalStore.Save(path, score, goals);
            Console.WriteLine($"Progress saved to {Path.GetFullPath(path)}.");
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Could not save progress: {exception.Message}");
        }
        catch (UnauthorizedAccessException exception)
        {
            Console.WriteLine($"Could not save progress: {exception.Message}");
        }
    }

    private static void LoadProgress(ref List<Goal> goals, ref long score)
    {
        string path = GetSavePath();
        try
        {
            (List<Goal> loadedGoals, long loadedScore) = GoalStore.Load(path);
            goals = loadedGoals;
            score = loadedScore;
            Console.WriteLine($"Progress loaded from {Path.GetFullPath(path)}.");
            DisplayScore(score);
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Could not load progress: {exception.Message}");
        }
        catch (UnauthorizedAccessException exception)
        {
            Console.WriteLine($"Could not load progress: {exception.Message}");
        }
        catch (FormatException exception)
        {
            Console.WriteLine($"The save file is invalid: {exception.Message}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"The save file is invalid: {exception.Message}");
        }
    }

    private static string GetSavePath()
    {
        string? path = ReadInput($"Save file (press Enter for {DefaultSaveFile}): ");
        return string.IsNullOrWhiteSpace(path) ? DefaultSaveFile : path.Trim();
    }

    private static int? ReadPositiveInt(string prompt)
    {
        while (true)
        {
            string? input = ReadInput(prompt);
            if (input == null || string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value)
                && value > 0)
            {
                return value;
            }

            Console.WriteLine("Enter a whole number greater than zero, or press Enter to cancel.");
        }
    }

    private static int? ReadNonNegativeInt(string prompt)
    {
        while (true)
        {
            string? input = ReadInput(prompt);
            if (input == null || string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value)
                && value >= 0)
            {
                return value;
            }

            Console.WriteLine("Enter a whole number of zero or more, or press Enter to cancel.");
        }
    }

    private static string? ReadInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
}

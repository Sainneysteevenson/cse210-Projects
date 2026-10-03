using System;
using System.Threading;

public class Activity
{
    private string _activityName;
    private string _description;
    private int _duration;

    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
        _duration = 0;
    }

    protected int GetDuration()
    {
        return _duration;
    }

    protected string GetActivityName()
    {
        return _activityName;
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_activityName} ---");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(2);

        Console.WriteLine();
        Console.WriteLine(
            $"You have completed another {_duration} seconds of the {_activityName}.");

        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] symbols = { "|", "/", "-", "\\" };

        DateTime startTime = DateTime.Now;
        int symbolIndex = 0;

        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            Console.Write(symbols[symbolIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            symbolIndex++;

            if (symbolIndex >= symbols.Length)
            {
                symbolIndex = 0;
            }
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
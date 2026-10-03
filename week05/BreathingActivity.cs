using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        bool breatheIn = true;

        while ((DateTime.Now - startTime).TotalSeconds < GetDuration())
        {
            if (breatheIn)
            {
                Console.Write("Breathe in...");
            }
            else
            {
                Console.Write("Breathe out...");
            }

            ShowCountDown(4);
            Console.WriteLine();

            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }
}
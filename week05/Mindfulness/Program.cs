/*using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
    }


}*/

using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity feature:
        // This program keeps track of how many times each mindfulness
        // activity is completed during the current program session.
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Show session activity counts");
            Console.WriteLine("  5. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity =
                        new BreathingActivity();

                    breathingActivity.Run();
                    breathingCount++;

                    PauseBeforeMenu();
                    break;

                case "2":
                    ReflectionActivity reflectionActivity =
                        new ReflectionActivity();

                    reflectionActivity.Run();
                    reflectionCount++;

                    PauseBeforeMenu();
                    break;

                case "3":
                    ListingActivity listingActivity =
                        new ListingActivity();

                    listingActivity.Run();
                    listingCount++;

                    PauseBeforeMenu();
                    break;

                case "4":
                    Console.WriteLine("Session Activity Counts");
                    Console.WriteLine();
                    Console.WriteLine(
                        $"Breathing activities completed: {breathingCount}");
                    Console.WriteLine(
                        $"Reflection activities completed: {reflectionCount}");
                    Console.WriteLine(
                        $"Listing activities completed: {listingCount}");

                    PauseBeforeMenu();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using the Mindfulness Program.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select 1-5.");
                    PauseBeforeMenu();
                    break;
            }
        }
    }

    private static void PauseBeforeMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Resume resume = new Resume();
        resume._name = "Jane Doe";

        resume._jobs.Add(new Job
        {
            _company = "Acme Corp",
            _jobTitle = "Software Engineer",
            _startYear = 2020,
            _endYear = 2024
        });

        resume._jobs.Add(new Job
        {
            _company = "Tech Solutions",
            _jobTitle = "Junior Developer",
            _startYear = 2018,
            _endYear = 2020
        });

        Console.WriteLine("Resume Menu");
        Console.WriteLine("1. Display resume");
        Console.WriteLine("2. Quit");
        Console.Write("Choose an option: ");

        string choice = Console.ReadLine() ?? "";

        if (choice == "1")
        {
            resume.Display();
        }
        else
        {
            Console.WriteLine("Goodbye!");
        }
    }
}
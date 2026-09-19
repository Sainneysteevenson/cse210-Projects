//using System;

//class Program
//{
    //static void Main(string[] args)
    //{
        /*Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");*/
    //}
//}
class Program
{
    static void Main(string[] args)
    {
        // Creativity feature:
        // The program contains multiple scriptures and randomly
        // chooses one scripture for the user to memorize.

        Random random = new Random();

        Reference[] references =
        {
            new Reference("John", 3, 16),
            new Reference("Proverbs", 3, 5, 6),
            new Reference("Philippians", 4, 13)
        };

        string[] scriptures =
        {
            "For God so loved the world that he gave his only begotten Son that whoever believes in him should not perish but have eternal life.",
            "Trust in the Lord with all your heart and do not lean on your own understanding. In all your ways acknowledge him and he will make straight your paths.",
            "I can do all things through Christ who strengthens me."
        };

        int selectedIndex = random.Next(references.Length);

        Scripture scripture = new Scripture(
            references[selectedIndex],
            scriptures[selectedIndex]);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");

            string input = Console.ReadLine() ?? "";

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}
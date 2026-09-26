/*using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
    }
}*/
class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video(
            "Learning C#",
            "Sainney",
            600);

        video1.AddComment(
            new Comment("Pascal", "This is a very helpful video."));

        video1.AddComment(
            new Comment("Marcus", "I learned something new today."));

        video1.AddComment(
            new Comment("David", "Great explanation!"));

        Video video2 = new Video(
            "Introduction to Programming",
            "Tech Channel",
            720);

        video2.AddComment(
            new Comment("Andy", "Good video."));

        video2.AddComment(
            new Comment("Sarah", "This was very useful."));

        video2.AddComment(
            new Comment("James", "Thank you for sharing this."));

        Video video3 = new Video(
            "Object-Oriented Programming",
            "Programming Academy",
            900);

        video3.AddComment(
            new Comment("Musseau", "I understand classes better now  The haitian culture."));

        video3.AddComment(
            new Comment("Mike", "Very clear explanation, Awesome!"));

        video3.AddComment(
            new Comment("Daniel", "I enjoyed this lesson.thanks for the Next week lessons."));

        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3
        };

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}
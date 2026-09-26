using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Object-Oriented Programming Tutorial", "CodeAcademy Pro", 1240);
        video1.AddComment(new Comment("Alice Johnson", "This explanation of abstraction made everything click for me!"));
        video1.AddComment(new Comment("Bob Miller", "Clear and concise examples. Thank you for making this!"));
        video1.AddComment(new Comment("Carlos Mendoza", "Best C# video on YouTube. Subscribed!"));
        video1.AddComment(new Comment("Diana Prince", "Loved the audio quality and visual diagrams."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Understanding Encapsulation and Data Hiding", "DevMastery", 780);
        video2.AddComment(new Comment("Ethan Hunt", "Protecting our code from ourselves—such a great concept!"));
        video2.AddComment(new Comment("Fiona Gallagher", "The car steering wheel analogy was brilliant."));
        video2.AddComment(new Comment("George Clark", "Helped me ace my programming exam today."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Top 10 Clean Code Practices in 2026", "Tech Lead Insights", 950);
        video3.AddComment(new Comment("Hannah Abbott", "Naming conventions and short methods really change code readability."));
        video3.AddComment(new Comment("Ian Malcolm", "Life finds a way... to write clean code! Great video."));
        video3.AddComment(new Comment("Julia Roberts", "Rule #4 about avoiding getters and setters everywhere blew my mind."));
        video3.AddComment(new Comment("Kevin Bacon", "Sharing this with my entire dev team right now."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Building Modern APIs with .NET 10", "Cloud Architecture Daily", 1520);
        video4.AddComment(new Comment("Laura Croft", "Incredible pacing and practical demo from scratch."));
        video4.AddComment(new Comment("Michael Scott", "I understand APIs now! That's what she said!"));
        video4.AddComment(new Comment("Nancy Wheeler", "The project structure shown at minute 12 is top tier."));
        videos.Add(video4);

        // Display all videos and their comments
        Console.WriteLine("=================================================");
        Console.WriteLine("           YOUTUBE VIDEO TRACKER REPORT          ");
        Console.WriteLine("=================================================");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title:  {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: \"{comment.GetCommentText()}\"");
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
        }
    }
}
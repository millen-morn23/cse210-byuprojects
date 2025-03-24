using System;
using System.Collections.Generic;

// Comment class stores individual comments
class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    // Constructor
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Video class stores video details and its list of comments
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments; // List of comments

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>(); // Initialize list
    }

    // Add a comment to the video
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Get the number of comments
    public int GetCommentCount()
    {
        return comments.Count;
    }

    // Display video details and comments
    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"  - {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

// Program execution
class Program
{
    static void Main()
    {
        // Creating video objects
        Video video1 = new Video("C# Basics", "John Doe", 600);
        Video video2 = new Video("OOP in C#", "Jane Smith", 1200);
        Video video3 = new Video("C# Design Patterns", "Mike Johnson", 1800);

        // Adding comments to videos
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Really helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Can you make a part 2?"));

        video2.AddComment(new Comment("David", "This was super informative."));
        video2.AddComment(new Comment("Emma", "Best tutorial I've seen!"));
        video2.AddComment(new Comment("Frank", "I learned so much, thank you."));

        video3.AddComment(new Comment("Grace", "Nice breakdown of patterns."));
        video3.AddComment(new Comment("Hannah", "Could you explain Singleton in more detail?"));
        video3.AddComment(new Comment("Isaac", "Solid content, keep it up!"));

        // Storing videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Displaying video details and comments
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}


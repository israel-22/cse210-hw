using System;
using System.Collections.Generic;

namespace YoutubeTracker
{
    public class Comment
    {
        public string CommenterName { get; set; }
        public string ConmmentText { get; set; }


        public Comment(string commenterName, string conmmentText)
        {
            CommenterName = commenterName;
            ConmmentText = conmmentText;
        }

    }

    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int DurationInSeconds { get; set; }
        private List<Comment> comments = new List<Comment>();

        public Video(string title, string author, int durationInSeconds)
        {
            Title = title;
            Author = author;
            DurationInSeconds = durationInSeconds;
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetCommentCount()
        { return comments.Count; }

        public void DisplayVideoInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Duration: {DurationInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (var comment in comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.ConmmentText}");
            }
            Console.WriteLine(new string ('-', 40));
        }
    }
class Program
{
        static void Main(string[] args)
        {
            Video video1 = new Video("C# Tutorial for Beginners", "John Doe", 600);
            video1.AddComment(new Comment("Alice", "Great tutorial!"));
            video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
            video1.AddComment(new Comment("Charlie", "I learned a lot from this."));

            Video video2 = new Video("Understanding Abstraction  in OOP", "Jane Doe", 720);
            video2.AddComment(new Comment("Daniel", "This really clarified things for me."));
            video2.AddComment(new Comment("Eve", "Thanks for the explanation!"));
            video2.AddComment(new Comment("Frank", "Awesome content!"));

            Video video3 = new Video("Top 10 Progaming lenguages", "Tech Guru", 900);
            video3.AddComment(new Comment("Grace", "I love Python!"));
            video3.AddComment(new Comment("Heidi", "JavaScript is so versatile."));
            video3.AddComment(new Comment("Ivan", "C# is my favorite for desktop apps."));

            List<Video> videos = new List<Video> { video1, video2, video3 };

            foreach (var video in videos)
            {
                video.DisplayVideoInfo();
            }
            Console.ReadLine();
    }
}

}




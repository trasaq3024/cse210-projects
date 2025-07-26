using System;

class Program
{
     static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Exploring Mars", "NASA", 300);
        video1.AddComment(new Comment("Alice", "Amazing journey!"));
        video1.AddComment(new Comment("Bob", "Loved the graphics."));
        video1.AddComment(new Comment("Charlie", "Can't wait for the next mission."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("How to Cook Jollof Rice", "Chef Tolu", 420);
        video2.AddComment(new Comment("Grace", "So delicious!"));
        video2.AddComment(new Comment("David", "Thanks for the recipe!"));
        video2.AddComment(new Comment("Emma", "Mine came out perfect!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Python Programming Basics", "CodeAcademy", 600);
        video3.AddComment(new Comment("Musa", "Very informative."));
        video3.AddComment(new Comment("Zainab", "This helped me pass my test."));
        video3.AddComment(new Comment("Sam", "Could you do a part two?"));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Top 10 Travel Destinations", "Wanderlust", 500);
        video4.AddComment(new Comment("Lily", "Adding these to my bucket list!"));
        video4.AddComment(new Comment("Paul", "Number 3 was my favorite."));
        video4.AddComment(new Comment("Nina", "Wish I could travel more."));
        videos.Add(video4);

        // Display videos and their comments
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
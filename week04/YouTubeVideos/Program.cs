using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video();
        video1._author = "CodeMaster";
        video1._title = "C# Fundamentals for Beginners - Part 1";
        video1._duration = 360;

        Comment comment1_1 = new Comment();
        comment1_1._name = "Sarah Johnson";
        comment1_1._text = "Excellent explanation, very clear and concise.";
        video1._comments.Add(comment1_1);

        Comment comment1_2 = new Comment();
        comment1_2._name = "Edward Manuel";
        comment1_2._text = "Good master class!";
        video1._comments.Add(comment1_2);

        Comment comment1_3 = new Comment();
        comment1_3._name = "Henry Cavil";
        comment1_3._text = "Very clear and concise!";
        video1._comments.Add(comment1_3);

        videos.Add(video1);

        // Video 2
        Video video2 = new Video();
        video2._author = "TechReview Pro";
        video2._title = "Complete iPhone 15 Pro Max Review";
        video2._duration = 720;

        Comment comment2_1 = new Comment();
        comment2_1._name = "Robert Wilson";
        comment2_1._text = "The camera is impressive, great review.";
        video2._comments.Add(comment2_1);

        Comment comment2_2 = new Comment();
        comment2_2._name = "Jennifer Lee";
        comment2_2._text = "Do you recommend buying it or waiting for the next one?";
        video2._comments.Add(comment2_2);

        Comment comment2_3 = new Comment();
        comment2_3._name = "David Brown";
        comment2_3._text = "Good battery analysis, very helpful.";
        video2._comments.Add(comment2_3);

        Comment comment2_4 = new Comment();
        comment2_4._name = "Lisa Martinez";
        comment2_4._text = "Already ordered mine, thanks for the review.";
        video2._comments.Add(comment2_4);

        videos.Add(video2);

        // Video 3
        Video video3 = new Video();
        video3._author = "Easy Cooking";
        video3._title = "Authentic Spanish Paella Recipe";
        video3._duration = 540;

        Comment comment3_1 = new Comment();
        comment3_1._name = "James Anderson";
        comment3_1._text = "The best recipe I've tried, delicious!";
        video3._comments.Add(comment3_1);

        Comment comment3_2 = new Comment();
        comment3_2._name = "Mary Taylor";
        comment3_2._text = "Can I substitute saffron with turmeric?";
        video3._comments.Add(comment3_2);

        Comment comment3_3 = new Comment();
        comment3_3._name = "John Taylor";
        comment3_3._text = "A beautiful kitchen!";
        video3._comments.Add(comment3_3);

        videos.Add(video3);

        // Video 4
        Video video4 = new Video();
        video4._author = "Fitness Life";
        video4._title = "Home Workout Routine for Beginners";
        video4._duration = 480;

        Comment comment4_1 = new Comment();
        comment4_1._name = "Olivia Martinez";
        comment4_1._text = "Loved the routine, very easy to follow.";
        video4._comments.Add(comment4_1);

        Comment comment4_2 = new Comment();
        comment4_2._name = "Daniel Wilson";
        comment4_2._text = "Great for starting out, I feel more active.";
        video4._comments.Add(comment4_2);

        Comment comment4_3 = new Comment();
        comment4_3._name = "Sophia Rodriguez";
        comment4_3._text = "How many times a week do you recommend doing it?";
        video4._comments.Add(comment4_3);

        videos.Add(video4);

        foreach (var item in videos)
        {
            item.GetDisplayText();
        }
    }
}
public class Video
{
    public string _title;
    public string _author;
    public int _duration;
    public List<Comment> _comments = new List<Comment>();

    public int GetCountComments()
    {
        return _comments.Count;
    }

    public void GetDisplayText()
    {
        Console.WriteLine("######################################################################");
        Console.WriteLine($"# Title: {_title}");
        Console.WriteLine($"# Author: {_author}");
        Console.WriteLine($"# Duration (sec): {_duration}");
        Console.WriteLine($"# Number of comments: {GetCountComments()}");
        Console.WriteLine("######################################################################");
        Console.WriteLine($"# Comments:");

        for (int i = 0; i < _comments.Count; i++)
        {
            Console.WriteLine($"\t[{i + 1}] {_comments[i]._name}");
            Console.WriteLine($"\tComment: {_comments[i]._text}");
        }
    }
}
public class Video(string title, string author, string length)
{
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
    public string Length { get; set; } = length;
    private readonly List<Comment> comments = [];


    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int NumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }



    public static List<Video> CreateSampleVideos()
    {
        Video video1 = new("C# Tutorial", "Alice", "15:30");
        Video video2 = new("Java Basics", "Bob", "12:45");
        Video video3 = new("Data Structures", "Charlie", "22:10");
        Video video4 = new("Machine Learning", "Diana", "18:20");

        // Add sample comments to videos
        video1.AddComments(Comment.CreateSampleCommentsForVideo1());
        video2.AddComments(Comment.CreateSampleCommentsForVideo2());
        video3.AddComments(Comment.CreateSampleCommentsForVideo3());
        video4.AddComments(Comment.CreateSampleCommentsForVideo4());

        return [video1, video2, video3, video4];
    }

    public void AddComments(List<Comment> newComments)
    {
        foreach (Comment comment in newComments)
        {
            AddComment(comment);
        }
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length}");
        Console.WriteLine($"Number of Comments: {NumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (Comment comment in GetComments())
        {
            comment.DisplayComment();
        }
        Console.WriteLine();
    }
}

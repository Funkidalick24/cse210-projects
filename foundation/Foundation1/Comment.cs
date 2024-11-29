public class Comment(string name, string text)
{
    public string Name { get; set; } = name;
    public string Text { get; set; } = text;

    public static List<Comment> CreateSampleCommentsForVideo1()
    {
        return
        [
            new Comment("Eve", "Great tutorial!"),
            new Comment("Frank", "Very helpful, thanks!"),
            new Comment("Grace", "Clear and concise.")
        ];
    }

    public static List<Comment> CreateSampleCommentsForVideo2()
    {
        return
        [
            new Comment("Henry", "Loved it!"),
            new Comment("Ivy", "Good introduction.")
        ];
    }

    public static List<Comment> CreateSampleCommentsForVideo3()
    {
        return
        [
            new Comment("Jack", "Informative.")
        ];
    }

    public static List<Comment> CreateSampleCommentsForVideo4()
    {
        return
        [
            new Comment("Kim", "Excellent content."),
            new Comment("Liam", "Well explained.")
        ];
    }

    public void DisplayComment()
    {
        Console.WriteLine($"{Name}: {Text}");
    }
}
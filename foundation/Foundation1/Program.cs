public class Program
{
    public static void Main()
    {
        List<Video> videos = Video.CreateSampleVideos();

        foreach (Video video in videos)
        {
            video.DisplayDetails();
        }
    }
}

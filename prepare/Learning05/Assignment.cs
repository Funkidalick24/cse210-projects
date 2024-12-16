public class Assignment(string studentName, string topic)
{
    private readonly string _studentName = studentName;
    private readonly string _topic = topic;

    // We will provide Getters for our private member variables so they can be accessed
    // later both outside the class as well is in derived classes.
    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetTopic()
    {
        return _topic;
    }

    public string GetSummary()
    {
        return _studentName + " - " + _topic;
    }
}